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
    }

    public void SpawnStartUnit(UnitType type)
    {
        TrySpawnNewUnit(0, type);
    }

    public Unit TrySpawnNewUnit(int level, UnitType type, Platform platformToSpawn = null)
    {
        Platform selectedPlatform;

        if (platformToSpawn == null)
            selectedPlatform = platforms.Find(x => !x.IsBusy);
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
