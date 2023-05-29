using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsInfo : MonoBehaviour
{
    public static UnitsInfo inst;
    public List<UnitInfo> InfoList = new List<UnitInfo>();
    public List<UnitInfo> OpenedUnits = new List<UnitInfo>();

    private CardPreview cardPreview;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
        {
            Destroy(gameObject);
        }

        cardPreview = FindObjectOfType<CardPreview>();
    }

    public UnitInfo GetInfo(int level, UnitType type)
    {
        return InfoList.Find(x => x.Level == level && x.Type == type);
    }

    public UnitInfo GetRandomOpenedInfo()
    {
        return OpenedUnits[UnityEngine.Random.Range(0, OpenedUnits.Count)];
    }

    public void OpenNewUnit(UnitInfo info)
    {
        if (OpenedUnits.Contains(info))
            return;
        OpenedUnits.Add(info);
        cardPreview.ShowPreview(info);
    }
}
