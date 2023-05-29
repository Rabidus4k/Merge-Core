using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragAndDrop : DragAndDropBase
{
    private Rigidbody _rigidbody;
    private float _startYPos;
    private BoardController _board;
    private Card card;

    private void Start()
    {
        card = GetComponent<Card>();
        _board = FindObjectOfType<BoardController>();
        _rigidbody = GetComponent<Rigidbody>();
        

        _startYPos = 0; // Better to not hardcode that one but whatever
    }

    protected override void OnMouseDown()
    {
        _rigidbody.isKinematic = false;
        UnitSelection.CallOnSelect(card.Info);
        base.OnMouseDown();
    }

    protected override void OnMouseDrag()
    {
        Vector3 newWorldPosition = new Vector3(_board.CurrentMousePosition.x, _startYPos + 1, _board.CurrentMousePosition.z);

        var difference = newWorldPosition - transform.position;

        var speed = 10 * difference;
        _rigidbody.velocity = speed;
        _rigidbody.rotation = Quaternion.Euler(new Vector3(speed.z, 0, -speed.x));
        base.OnMouseDrag();
    }

    protected override void OnMouseUp()
    {
        _rigidbody.isKinematic = true;
        UnitSelection.CallOnDeselect(card.Info);
        base.OnMouseUp();
    }
}
