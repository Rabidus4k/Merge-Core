using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public TMPro.TextMeshPro UnitLevelText;
    public int Level;
    public UnitType Type;
    public bool IsEnemy = false;

    private UnitHealth unitHealth;
    private BaseAttack baseAttack;

    private UnitInfo info;

    private void Awake()
    {
        unitHealth = GetComponent<UnitHealth>();
        baseAttack = GetComponent<BaseAttack>();
    }

    public void Init(UnitInfo newinfo)
    {
        info = newinfo;

        InitBaseValues();
        InitHealth();
        InitAttack();
    }

    private void InitBaseValues()
    {
        IsEnemy = info.IsEnemy;
        Level = info.Level;
        Type = info.Type;

        UnitLevelText.SetText($"{Type}:{Level}");
    }

    private void InitAttack()
    {
        baseAttack.Damage = info.Damage;
    }

    private void InitHealth()
    {
        unitHealth.UpdateMaxHealth(info.Health);
    }
}
