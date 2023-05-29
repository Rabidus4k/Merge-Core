using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacement : MonoBehaviour
{
    [SerializeField]
    private LayerMask platformLayerMask;
    private CardDragAndDrop cardDragAndDrop;
    private Camera cam;

    public event Action<GameObject> OnPlacedCard;

    private void Awake()
    {
        cardDragAndDrop = GetComponent<CardDragAndDrop>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        cardDragAndDrop.OnEndDrag += TryPlaceCard;
    }

    private void OnDisable()
    {
        cardDragAndDrop.OnEndDrag -= TryPlaceCard;
    }

    private void TryPlaceCard()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, platformLayerMask))
        {
            if (hit.collider.GetComponent<Platform>().TryAttach(gameObject.GetComponent<Card>().UnitInfo))
            {
                OnPlacedCard?.Invoke(gameObject);
            }
        }
    }
}
