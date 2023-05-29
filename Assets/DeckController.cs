using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{
    public int MaxCards = 3;
    [SerializeField]
    private Vector3 hidePos;
    [SerializeField]
    private Vector3 showPos;

    private int currentCardsCount = 0;

    private TrashCan trashCan;

    private void Awake()
    {
        trashCan = FindObjectOfType<TrashCan>();
    }

    private void OnEnable()
    {
        trashCan.OnRemove += DeleteCard;
    }

    private void OnDisable()
    {
        trashCan.OnRemove -= DeleteCard;
    }

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

    public void SpawnNewCard(int price)
    {
        currentCardsCount++;

        var card = ((GameObject)Instantiate(Resources.Load("Card"), transform));

        card.GetComponent<DragAndDropBase>().OnBeginDrag += UnParent;
        card.GetComponent<DragAndDropBase>().OnEndDrag += Parent;

        card.GetComponent<CardPlacement>().OnPlacedCard += DeleteCard;

        card.GetComponent<Card>().Init(UnitsInfo.inst.GetRandomOpenedInfo());

        void UnParent()
        {
            card.transform.parent = null;
            HidePanel();
        }

        void Parent()
        {
            ShowPanel();
            card.transform.parent = transform;
            card.transform.localPosition = Vector3.zero;
            card.transform.rotation = transform.rotation;
        }

    }


    public void ShowPanel()
    {
        gameObject.transform.position = showPos;
    }

    public void HidePanel()
    {
        gameObject.transform.position = hidePos;
    }

    private void DeleteCard(GameObject obj)
    {
        Destroy(obj);
        if (obj.TryGetComponent(out Card card))
            currentCardsCount--;
    }
}
