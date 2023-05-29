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

    private UnitInfo info;

    private void Awake()
    {
        unitStateController = GetComponent<UnitStateController>();
        unitHealth = GetComponent<UnitHealth>();
        baseAttack = GetComponent<BaseAttack>();
    }

    public void Init(UnitInfo newinfo)
    {
        info = newinfo;

        InitModel();
        InitBaseValues();
        InitHealth();
        InitAttack();
    }

    private void InitModel()
    {
        if (info.Model)
        {
            var model = Instantiate(info.Model, ModelSpawnPoint);
            unitStateController.Animator = model.GetComponent<Animator>();
        }
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
        baseAttack.MinDistanceToTarget = info.MinDistanceToTarget;
    }

    private void InitHealth()
    {
        unitHealth.UpdateMaxHealth(info.Health);
    }
}
