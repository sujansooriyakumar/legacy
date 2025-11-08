using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHitDetection : MonoBehaviour
{
    Rigidbody rb;
    public float forceMagnitude = 50;
    public UnityEvent OnHit;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Hit(Vector3 hitOrigin, float impact)
    {
        StopAllCoroutines(); // prevent stacked hits
        StartCoroutine(Knockback(hitOrigin, impact, 0.1f));
        OnHit?.Invoke();
    }

    private IEnumerator Knockback(Vector3 source, float distance, float duration)
    {
        Vector3 start = transform.position;

        // Direction away from the hit source on the horizontal plane
        Vector3 dir = (start - source);
        if (dir.sqrMagnitude < 0.001f)
            dir = -transform.forward; // fallback in case of overlap

        dir.y = 0f;
        dir.Normalize();

        Vector3 target = start + dir * distance;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);
            transform.position = Vector3.Lerp(start, target, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }



}
