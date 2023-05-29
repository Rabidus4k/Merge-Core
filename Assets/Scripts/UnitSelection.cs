using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject selectObject; 

    private DragAndDropBase dragAndDrop3D;

    private static event Action<UnitInfo> OnSelect;
    private static event Action<UnitInfo> OnDeSelect;

    private Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        dragAndDrop3D = GetComponent<DragAndDropBase>();
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

    public static void CallOnSelect(UnitInfo info)
    {
        OnSelect?.Invoke(info);
    }

    public static void CallOnDeselect(UnitInfo info)
    {
        OnDeSelect?.Invoke(info);
    }

    private void OnDeSelectPerform()
    {
        OnDeSelect?.Invoke(unit.Info);
    }

    public void OnSelectPerform()
    {
        OnSelect?.Invoke(unit.Info);
    }

    private void Select(UnitInfo info)
    {
        if (unit.IsEnemy)
            return;

        if (unit.Info == info)
        {
            selectObject.SetActive(true);
        }
    }

    private void DeSelect(UnitInfo compareUnit)
    {
        if (unit.IsEnemy)
            return;

        if (unit.Level == compareUnit.Level && unit.Type == compareUnit.Type)
        {
            selectObject.SetActive(false);
        }
    }
}
