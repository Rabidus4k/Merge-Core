using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop3D : DragAndDropBase
{
    [SerializeField]
    private LayerMask planeLayerMask;

    private Vector3 proectionToScreen => cam.WorldToScreenPoint(transform.position);
    private Vector3 mousePosition;
    private Camera cam;

    private Unit unit;
    private void Awake()
    {
        cam = Camera.main;
        unit = GetComponent<Unit>();
    }

    protected override void OnMouseDown()
    {
        if (unit.IsEnemy)
            return;

        if (GameStateController.inst.State != GameState.Prepare)
            return;

        mousePosition = Input.mousePosition - proectionToScreen;
        base.OnMouseDown();
    }

    protected override void OnMouseDrag()
    {
        if (unit.IsEnemy)
            return;

        if (GameStateController.inst.State != GameState.Prepare)
            return;

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, planeLayerMask))
        {
            transform.position = hit.point;
        }

        base.OnMouseDrag();
    }

    protected override void OnMouseUp()
    {
        if (unit.IsEnemy)
            return;

        if (GameStateController.inst.State != GameState.Prepare)
            return;

        base.OnMouseUp();
    }
}
