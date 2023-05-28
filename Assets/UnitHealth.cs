using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public float MaxHealth;
    private float currentHealth;

    public event Action OnDead;

    public void UpdateMaxHealth(float value)
    {
        MaxHealth = value;
        currentHealth = MaxHealth;
    }

    public void ReduceHealth(float ammount) 
    {
        currentHealth -= ammount;
        if (currentHealth <= 0)
        {
            OnDead?.Invoke();
            Destroy(gameObject);
        }
    }
}
