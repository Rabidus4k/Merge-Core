using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum UnitType 
{
    First, Second
}

[CreateAssetMenu(fileName = "UnitInfo", menuName = "Unit")]
public class UnitInfo : ScriptableObject
{
    public UnitType Type;
    public int Level = 0;
    public GameObject Model;
}
