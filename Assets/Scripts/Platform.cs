using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public UnitInfo StartUnit;

    [SerializeField]
    private SpriteRenderer activeStateObject;
    [SerializeField]
    private Color activeColor;
    [SerializeField]
    private Color deactiveColor;

    public bool IsEnemy;

    public bool IsBusy => unit != null;

    private UnitSpawner unitSpawner;
    private bool isActive = false;
    private Unit unit;
    
    private void Awake()
    {
        unitSpawner = FindObjectOfType<UnitSpawner>();
    }

    private void Start()
    {
        GameStateController.inst.OnGameStarted += HidePlatforms;
    }

    private void OnDisable()
    {
        GameStateController.inst.OnGameStarted -= HidePlatforms;
    }

    private void HidePlatforms()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        if (isActive)
            return;

        activeStateObject.color = activeColor;
        isActive = true;
    }

    public void Deactivate()
    {
        if (!isActive)
            return;

        activeStateObject.color = deactiveColor;
        isActive = false;
    }

    public bool TryAttach(Unit newUnit)
    {
        if (IsEnemy)
            return false;

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

    public bool TryAttach(UnitInfo newUnit)
    {
        if (IsEnemy)
            return false;

        if (unit == null)
        {
            var result = unitSpawner.SpawnNewUnit(newUnit, this);
            return true;
        }
        else if (unit.Level == newUnit.Level && unit.Type == newUnit.Type)
        {
            var oldUnit = unit.gameObject;
            var result = unitSpawner.TrySpawnNewUnit(unit.Level + 1, unit.Type, this);
            if (result)
            {
                Destroy(oldUnit);
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
        unit.GetComponent<DragAndDropBase>().OnBeginDrag += ClearPlatform;
        newUnit.transform.position = transform.position;

        void ClearPlatform()
        {
            unit.GetComponent<DragAndDropBase>().OnBeginDrag -= ClearPlatform;
            unit = null;
        }
    }
}
