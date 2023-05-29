using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 RotateVector;

    private void Update()
    {
        transform.Rotate(RotateVector);
    }
}
