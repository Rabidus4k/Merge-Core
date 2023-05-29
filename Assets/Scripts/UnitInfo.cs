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
    [Space]
    [Header("Base Settings")]
    public UnitType Type;
    public bool IsEnemy = false;
    public int Level = 0;
    public float Health = 100;
    public GameObject Model;
    [Space]
    [Header("Attack")]
    public float Damage = 1;
    public float MinDistanceToTarget = 1;
    [Space]
    [Header("Card")]
    public Sprite CardSprite;
}
