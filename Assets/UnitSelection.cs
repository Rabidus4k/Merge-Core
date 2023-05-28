using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject selectObject; 

    private DragAndDrop3D dragAndDrop3D;

    private static event Action<Unit> OnSelect;
    private static event Action<Unit> OnDeSelect;

    private Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        dragAndDrop3D = GetComponent<DragAndDrop3D>();
    }

    private void OnEnable()
    {
        dragAndDrop3D.OnBeginDrag += OnSelectPerform;
        dragAndDrop3D.OnEndDrag += OnDeSelectPerform;

        OnSelect += Select;
        OnDeSelect += DeSelect;
    }

    private void OnDisable()
    {
        dragAndDrop3D.OnBeginDrag -= OnSelectPerform;
        dragAndDrop3D.OnEndDrag -= OnDeSelectPerform;

        OnSelect -= Select;
        OnDeSelect -= DeSelect;
    }

    private void OnDeSelectPerform()
    {
        OnDeSelect?.Invoke(unit);
    }

    public void OnSelectPerform()
    {
        OnSelect?.Invoke(unit);
    }

    private void Select(Unit compareUnit)
    {
        if (unit.IsEnemy)
            return;

        if (unit.Level == compareUnit.Level && unit.Type == compareUnit.Type)
        {
            selectObject.SetActive(true);
        }
    }

    private void DeSelect(Unit compareUnit)
    {
        if (unit.IsEnemy)
            return;

        if (unit.Level == compareUnit.Level && unit.Type == compareUnit.Type)
        {
            selectObject.SetActive(false);
        }
    }
}
