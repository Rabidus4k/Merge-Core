using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI moneyAmmountText;

    public int Money = 1000000;
    public PriceInfo PriceInfo;

    private void Awake()
    {
        moneyAmmountText.SetText(Money.ToString());
    }

    public int GetPrice(int index)
    {
        return PriceInfo.Info[index];
    }

    public bool TrySpendMoney(int money)
    {
        if (money <= Money)
        {
            Money -= money;
            moneyAmmountText.SetText(Money.ToString());
            return true;
        } 
        else
        {
            return false;
        }
    }
}
