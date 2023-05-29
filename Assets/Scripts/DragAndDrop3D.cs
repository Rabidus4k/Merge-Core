using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop3D : MonoBehaviour
{
    [SerializeField]
    private Vector3 transformMultiplier = Vector3.up;
    [SerializeField]
    private LayerMask planeLayerMask;

    private Vector3 proectionToScreen => cam.WorldToScreenPoint(transform.position);
    private Vector3 mousePosition;
    private Camera cam;

    public event Action OnBeginDrag;
    public event Action OnDrag;
    public event Action OnEndDrag;

    private Unit unit;
    private void Awake()
    {
        cam = Camera.main;
        unit = GetComponent<Unit>();
    }

    private void OnMouseDown()
    {
        if (unit.IsEnemy)
            return;

        if (GameStateController.inst.State != GameState.Prepare)
            return;

        mousePosition = Input.mousePosition - proectionToScreen;
        OnBeginDrag?.Invoke();
    }

    private void OnMouseDrag()
    {
        if (unit.IsEnemy)
            return;

        if (GameStateController.inst.State != GameState.Prepare)
            return;

        //var newPosition = cam.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        //newPosition = new Vector3(newPosition.x * transformMultiplier.x, newPosition.y * transformMultiplier.y, newPosition.z * transformMultiplier.z);
        //transform.position = newPosition;

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, planeLayerMask))
        {
            transform.position = hit.point;
        }

        OnDrag?.Invoke();
    }
    private void OnMouseUp()
    {
        if (unit.IsEnemy)
            return;

        if (GameStateController.inst.State != GameState.Prepare)
            return;

        OnEndDrag?.Invoke();
    }
}
