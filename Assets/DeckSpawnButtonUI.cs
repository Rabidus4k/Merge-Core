using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSpawnButtonUI : BaseButtonUI
{
    private DeckController deckController;
    protected override void Awake()
    {
        base.Awake();
        deckController = FindObjectOfType<DeckController>();
    }

    protected override void OnClickPerform()
    {
        if (GameStateController.inst.State != GameState.Prepare)
            return;

        if (!deckController.CanSpawnNewCard())
            return;

        if (moneyController.TrySpendMoney(currentPrice))
        {
            deckController.SpawnNewCard(currentPrice);
            UpdatePrice();
        }
    }
}