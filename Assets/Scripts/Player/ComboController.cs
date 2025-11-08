using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboController : MonoBehaviour
{
    HitboxController hitboxController;
    List<AttackHitboxData> attacks;
    public float linkWindow;
    private void Start()
    {
        hitboxController = GetComponent<HitboxController>();
        attacks = hitboxController.hitboxData;
        foreach(AttackHitboxData att in attacks)
        {
            att.hitbox.OnHit += ComboHit;
        }
    }

    private void ComboHit()
    {
        StateController.Instance.UpdateState(PlayerState.LINK);

        StartCoroutine(LinkStateTimer());

    }

    private  IEnumerator LinkStateTimer()
    {
        float i = 0;
        while( i < linkWindow)
        {
            i += Time.deltaTime;
            yield return null;
        }
        StateController.Instance.UpdateState(PlayerState.ACTIVE);
        yield return null;

    }
}
