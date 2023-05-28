using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButtonUI : MonoBehaviour
{
    [SerializeField]
    private UnitType Type;
    [SerializeField]
    private TMPro.TextMeshProUGUI priceText;

    private Button button;
    private UnitSpawner unitSpawner;

    private MoneyController moneyController;
    private int currentIndex = 0;
    private int currentPrice = 0;

    private void Awake()
    {
        moneyController = FindObjectOfType<MoneyController>();
        unitSpawner = FindObjectOfType<UnitSpawner>();
        button = GetComponent<Button>();
    }

    private void Start()
    {
        UpdatePrice();
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
        if (!unitSpawner.CanSpawnNewUnit())
            return;

        if (moneyController.TrySpendMoney(currentPrice))
        {
            unitSpawner.SpawnStartUnit(Type);
            UpdatePrice();
        }
    }

    private void UpdatePrice()
    {
        currentPrice = moneyController.GetPrice(currentIndex);
        currentIndex++;
        priceText.SetText(currentPrice.ToString());
    }

}
