using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject activeStateObject;
    
    public bool IsBusy => unit != null;

    private UnitSpawner unitSpawner;
    private bool isActive = false;
    private Unit unit;

    private void Awake()
    {
        unitSpawner = FindObjectOfType<UnitSpawner>();
    }

    public void Activate()
    {
        if (isActive)
            return;

        activeStateObject.SetActive(true);
        isActive = true;
    }

    public void Deactivate()
    {
        if (!isActive)
            return;

        activeStateObject.SetActive(false);
        isActive = false;
    }

    public bool TryAttach(Unit newUnit)
    {
        if (unit == null)
        {
            Attach(newUnit);
            return true;
        }
        else if (unit.Level == newUnit.Level && unit.Type == newUnit.Type)
        {
            var oldUnit = unit.gameObject;
            var result = unitSpawner.TrySpawnNewUnit(unit.Level + 1, unit.Type, this);
            if (result)
            {
                Destroy(oldUnit);
                Destroy(newUnit.gameObject);
                return true;    
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void Attach(Unit newUnit)
    {
        unit = newUnit;
        unit.GetComponent<DragAndDrop3D>().OnBeginDrag += ClearPlatform;
        newUnit.transform.position = transform.position;

        void ClearPlatform()
        {
            unit.GetComponent<DragAndDrop3D>().OnBeginDrag -= ClearPlatform;
            unit = null;
        }
    }
}
