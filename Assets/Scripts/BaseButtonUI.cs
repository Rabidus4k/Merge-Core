using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButtonUI : MonoBehaviour
{
    [SerializeField]
    protected TMPro.TextMeshProUGUI priceText;

    protected Button button;

    protected MoneyController moneyController;
    protected int currentIndex = 0;
    protected int currentPrice = 0;

    protected virtual void Awake()
    {
        moneyController = FindObjectOfType<MoneyController>();
        button = GetComponent<Button>();
    }

    protected void Start()
    {
        UpdatePrice();
    }

    protected void OnEnable()
    {
        button.onClick.AddListener(OnClickPerform);
    }

    protected void OnDisable()
    {
        button.onClick.RemoveListener(OnClickPerform);
    }

    protected virtual void OnClickPerform()
    {

    }

    protected void UpdatePrice()
    {
        currentPrice = moneyController.GetPrice(currentIndex);
        currentIndex++;
        priceText.SetText(currentPrice.ToString());
    }

}
