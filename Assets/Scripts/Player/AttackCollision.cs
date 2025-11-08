using System;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public bool hitboxActive = false;
    public event Action OnHit;
    AttackData attackData;

    public void InitializeAttackData(AttackSO attack)
    {
        attackData = new AttackData();
        attackData.dmg = attack.dmg;
        attackData.knockback = attack.knockback;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!hitboxActive) return;
        if (other.gameObject.GetComponent<EnemyHitDetection>() == null) return;
        EnemyHitDetection enemy = other.gameObject.GetComponent<EnemyHitDetection>();

        Vector3 hitPoint = other.ClosestPoint(transform.position);

        enemy.Hit(hitPoint, attackData.knockback);

        OnHit?.Invoke();
        StateController.Instance.UpdateState(PlayerState.LINK);
    }

    public void ActivateHitbox() {  hitboxActive = true; }
    public void DeactivateHitbox() { hitboxActive= false; }
}

public class AttackData
{
    public float dmg;
    public float knockback;
}