using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI levelText;
    [SerializeField]
    private TMPro.TextMeshProUGUI damageText;
    [SerializeField]
    private TMPro.TextMeshProUGUI healthText;

    public Image ImageToChange;
    public UnitInfo Info => info;
    private UnitInfo info;
    public void Init(UnitInfo newInfo)
    {
        info = newInfo;
        ImageToChange.sprite = info.CardSprite;

        InitText();
    }

    private void InitText()
    {
        levelText.SetText(info.Level.ToString());
        damageText.SetText(info.Damage.ToString());
        healthText.SetText(info.Health.ToString());
    }
}
