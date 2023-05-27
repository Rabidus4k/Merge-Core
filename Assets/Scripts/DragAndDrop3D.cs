using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop3D : MonoBehaviour
{
    [SerializeField]
    private Vector3 transformMultiplier = Vector3.up;
    private Vector3 proectionToScreen => cam.WorldToScreenPoint(transform.position);
    private Vector3 mousePosition;
    private Camera cam;

    public event Action OnBeginDrag;
    public event Action OnDrag;
    public event Action OnEndDrag;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - proectionToScreen;
        OnBeginDrag?.Invoke();
    }

    private void OnMouseDrag()
    {
        var newPosition = cam.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        newPosition = new Vector3(newPosition.x * transformMultiplier.x, newPosition.y * transformMultiplier.y, newPosition.z * transformMultiplier.z);
        transform.position = newPosition;
        OnDrag?.Invoke();
    }
    private void OnMouseUp()
    {
        OnEndDrag?.Invoke();
    }
}
