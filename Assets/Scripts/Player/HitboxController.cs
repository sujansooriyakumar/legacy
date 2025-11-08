
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public List<AttackHitboxData> hitboxData;
    private void Start()
    {
        InitializeHitboxData();
    }

    private void InitializeHitboxData()
    {
        foreach(AttackHitboxData data in hitboxData)
        {
            data.hitbox.InitializeAttackData(data.attackData);
        }
    }
    public void ActivateHitbox(int index)
    {
        hitboxData[index].hitbox.ActivateHitbox();
    }

    public void DeactivateHitbox(int index)
    {

        hitboxData[index].hitbox.DeactivateHitbox();
    }
}


[Serializable]
public class AttackHitboxData {
    public AttackSO attackData;
    public AttackCollision hitbox;

}

