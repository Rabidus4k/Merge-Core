using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public event Action<GameObject> OnRemove;

    public void Remove(GameObject card) 
    {
        OnRemove?.Invoke(card);
    }
}
