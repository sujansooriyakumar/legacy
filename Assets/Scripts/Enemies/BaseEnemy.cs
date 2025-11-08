using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public abstract void Patrol();
    public abstract void Attack();

    public abstract void Chase();
}
