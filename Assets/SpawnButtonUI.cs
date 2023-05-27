using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButtonUI : MonoBehaviour
{
    [SerializeField]
    private UnitType Type;

    private Button button;
    private UnitSpawner unitSpawner;

    private void Awake()
    {
        unitSpawner = FindObjectOfType<UnitSpawner>();
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClickPerform);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClickPerform);
    }

    public void OnClickPerform()
    {
        unitSpawner.SpawnStartUnit(Type);
    }
}
