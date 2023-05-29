using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitFindTarget : MonoBehaviour
{
    public Transform Target
    {
        get
        {
            if (target == null)
                target = FindTarget();

            return target;
        }
    }

    private Transform target;
    private Unit unit;
    private List<Unit> allUnits = new List<Unit>();


    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public Transform FindTarget()
    {
        allUnits = FindObjectsOfType<Unit>().ToList();

        allUnits = allUnits.Where(x => x != null && x.IsEnemy != unit.IsEnemy && x != unit).ToList();
        
        if (allUnits.Count == 0)
            return null;

        return allUnits.OrderBy(x => Vector3.Distance(transform.position, x.transform.position))
            .ToList()
            .First()?.transform;
    }
}
