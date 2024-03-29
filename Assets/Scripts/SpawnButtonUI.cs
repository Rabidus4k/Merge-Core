using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButtonUI : BaseButtonUI
{
    [SerializeField]
    private UnitType Type;
    private UnitSpawner unitSpawner;

    protected override void Awake()
    {
        base.Awake();
        unitSpawner = FindObjectOfType<UnitSpawner>();
    }

    protected override void OnClickPerform()
    {
        if (GameStateController.inst.State != GameState.Prepare)
            return;

        if (!unitSpawner.CanSpawnNewUnit())
            return;

        if (moneyController.TrySpendMoney(currentPrice))
        {
            unitSpawner.SpawnStartUnit(Type);
            UpdatePrice();
        }
    }
}
