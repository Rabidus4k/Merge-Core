using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    private List<Platform> platforms = new List<Platform>();

    private void Awake()
    {
        platforms = FindObjectsOfType<Platform>().ToList();
        InitializeStartUnits();
    }

    private void InitializeStartUnits()
    {
        var startPlatforms = platforms.Where(x => x.StartUnit != null);

        foreach (var platform in startPlatforms)
        {
            Unit spawnedUnit = ((GameObject)Instantiate(Resources.Load("Unit"))).GetComponent<Unit>();
            spawnedUnit.Init(platform.StartUnit, true);
            platform.Attach(spawnedUnit);
        }
    }

    public void SpawnStartUnit(UnitType type)
    {
        TrySpawnNewUnit(0, type);
    }

    public bool CanSpawnNewUnit()
    {
        var selectedPlatform = platforms.Find(x => !x.IsBusy && !x.IsEnemy);

        if (selectedPlatform == null)
            return false;
        else
            return true;
    }

    public Unit TrySpawnNewUnit(int level, UnitType type, Platform platformToSpawn = null)
    {
        Platform selectedPlatform;

        if (platformToSpawn == null)
            selectedPlatform = platforms.Find(x => !x.IsBusy && !x.IsEnemy);
        else
            selectedPlatform = platformToSpawn;

        if (selectedPlatform)
        {
            var unitInfo = UnitsInfo.inst.GetInfo(level, type);
            if (unitInfo)
            {
                Unit spawnedUnit = ((GameObject)Instantiate(Resources.Load("Unit"))).GetComponent<Unit>();
                spawnedUnit.Init(unitInfo);

                selectedPlatform.Attach(spawnedUnit);

                return spawnedUnit;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
}
