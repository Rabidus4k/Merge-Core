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
    [SerializeField]
    private Button showHideButton;

    private bool panelIsShow = true;
    private int currentCardsCount = 0;

    private TrashCan trashCan;

    private void Awake()
    {
        trashCan = FindObjectOfType<TrashCan>();
        showHideButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        trashCan.OnRemove += DeleteCard;
        showHideButton.onClick.AddListener(TogglePanel);
    }


    private void OnDisable()
    {
        trashCan.OnRemove -= DeleteCard;
        showHideButton.onClick.RemoveListener(TogglePanel);
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
        showHideButton.gameObject.SetActive(true);
        ShowPanel();

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


    private void TogglePanel()
    {
        if (panelIsShow)
        {
            HidePanel();
            panelIsShow = false;
        }
        else
        {
            ShowPanel();
            panelIsShow = true;
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
        if (obj.TryGetComponent(out Card card))
        {
            currentCardsCount--;
            if (currentCardsCount == 0)
            {
                showHideButton.gameObject.SetActive(false);
            }
        }
        Destroy(obj);
    }
}
