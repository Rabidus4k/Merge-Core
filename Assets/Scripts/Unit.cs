using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private Transform ModelSpawnPoint;

    public TMPro.TextMeshPro UnitLevelText;
    public int Level;
    public UnitType Type;
    public bool IsEnemy = false;

    private UnitHealth unitHealth;
    private BaseAttack baseAttack;
    private UnitStateController unitStateController;

    public UnitInfo Info;

    private void Awake()
    {
        unitStateController = GetComponent<UnitStateController>();
        unitHealth = GetComponent<UnitHealth>();
        baseAttack = GetComponent<BaseAttack>();
    }

    public void Init(UnitInfo newinfo)
    {
        Info = newinfo;

        InitModel();
        InitBaseValues();
        InitHealth();
        InitAttack();
    }

    private void InitModel()
    {
        if (Info.Model)
        {
            var model = Instantiate(Info.Model, ModelSpawnPoint);
            unitStateController.Animator = model.GetComponent<Animator>();
        }
    }

    private void InitBaseValues()
    {
        IsEnemy = Info.IsEnemy;
        Level = Info.Level;
        Type = Info.Type;

        UnitLevelText.SetText($"{Type}:{Level}");
    }

    private void InitAttack()
    {
        baseAttack.Damage = Info.Damage;
        baseAttack.MinDistanceToTarget = Info.MinDistanceToTarget;
    }

    private void InitHealth()
    {
        unitHealth.UpdateMaxHealth(Info.Health);
    }
}
