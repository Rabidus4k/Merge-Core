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
    public bool IsEnemy = false;
    public int Level = 0;
    public float Health = 100;
    public float Damage = 1;
    public GameObject Model;
}
