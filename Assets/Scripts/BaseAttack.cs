using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    public float MinDistanceToTarget = 1;
    public float Damage;
    public virtual void PerformAttack(Transform target)
    {

    }
}
