using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public TMPro.TextMeshPro UnitLevelText;
    public int Level;
    public UnitType Type;
    public bool IsEnemy = false;

    public void Init(UnitInfo info, bool isEnemy = false)
    {
        IsEnemy = isEnemy;
        Level = info.Level;
        Type = info.Type;

        UnitLevelText.SetText($"{Type}:{Level}");
    }
}
