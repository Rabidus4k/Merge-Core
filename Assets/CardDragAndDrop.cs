using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragAndDrop : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _startYPos;
    private BoardController _board;

    public event Action OnBeginDrag;
    public event Action OnDrag;
    public event Action OnEndDrag;

    void Start()
    {
        _board = FindObjectOfType<BoardController>();
        _rigidbody = GetComponent<Rigidbody>();

        _startYPos = 0; // Better to not hardcode that one but whatever
    }

    private void OnMouseDown()
    {
        _rigidbody.isKinematic = false;
        OnBeginDrag?.Invoke();
    }

    private void OnMouseDrag()
    {
        Vector3 newWorldPosition = new Vector3(_board.CurrentMousePosition.x, _startYPos + 1, _board.CurrentMousePosition.z);

        var difference = newWorldPosition - transform.position;

        var speed = 10 * difference;
        _rigidbody.velocity = speed;
        _rigidbody.rotation = Quaternion.Euler(new Vector3(speed.z, 0, -speed.x));
        OnDrag?.Invoke();
    }

    private void OnMouseUp()
    {
        _rigidbody.isKinematic = true;
        OnEndDrag?.Invoke();
    }
}
