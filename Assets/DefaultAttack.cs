using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : BaseAttack
{
    public override void PerformAttack(Transform target)
    {
        //TODO: ������� ��� ��������� � �����������
        var a = target.GetComponent<UnitHealth>();
        a.ReduceHealth(Damage);
    }
}
