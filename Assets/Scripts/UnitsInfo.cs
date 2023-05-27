using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsInfo : MonoBehaviour
{
    public static UnitsInfo inst;
    public List<UnitInfo> InfoList = new List<UnitInfo>();


    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public UnitInfo GetInfo(int level, UnitType type)
    {
        return InfoList.Find(x => x.Level == level && x.Type == type);
    }
}
