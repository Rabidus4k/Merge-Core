using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField]
    private LayerMask trashLayerMask;

    private Camera cam;
    private DragAndDropBase dragAndDropBase;

    private void Awake()
    {
        cam = Camera.main;
        dragAndDropBase = GetComponent<DragAndDropBase>();
    }

    private void OnEnable()
    {
        dragAndDropBase.OnEndDrag += TryRemoveCard;
    }

    private void OnDisable()
    {
        dragAndDropBase.OnEndDrag -= TryRemoveCard;
    }

    private void TryRemoveCard()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, trashLayerMask))
        {
            if (hit.collider.TryGetComponent(out TrashCan trash))
            {
                trash.Remove(gameObject);
            }
        }
    }
}
