using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropBase : MonoBehaviour
{
    public event Action OnBeginDrag;
    public event Action OnDrag;
    public event Action OnEndDrag;

    protected virtual void OnMouseDown()
    {
        OnBeginDrag?.Invoke();
    }

    protected virtual void OnMouseDrag()
    {
        OnDrag?.Invoke();
    }

    protected virtual void OnMouseUp()
    {
        OnEndDrag?.Invoke();
    }
}
