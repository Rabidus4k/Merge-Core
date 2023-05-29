using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{
    public int MaxCards = 3;
    private int currentCardsCount = 0;


    public bool CanSpawnNewCard()
    {
        if (currentCardsCount == MaxCards)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SpawnNewCard()
    {
        currentCardsCount++;

        var card = ((GameObject)Instantiate(Resources.Load("Card"), transform));
        card.GetComponent<CardDragAndDrop>().OnEndDrag += ReturnToDeck;
        card.GetComponent<CardPlacement>().OnPlacedCard += DeleteCard;
        card.GetComponent<Card>().Init(UnitsInfo.inst.GetRandomOpenedInfo());

        void ReturnToDeck()
        {
            card.transform.position = transform.position;
        }
    }

    private void DeleteCard(GameObject card)
    {
        currentCardsCount--;
        Destroy(card);
    }
}
