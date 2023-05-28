using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PriceInfo", menuName = "Price")]
public class PriceInfo : ScriptableObject
{
    public List<int> Info = new List<int>();
}
