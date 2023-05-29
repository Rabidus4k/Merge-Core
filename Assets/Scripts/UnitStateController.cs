using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : MonoBehaviour
{
    public Animator Animator
    {
        get
        {
            return animator;
        }
        set
        {
            animator = value;
        }
    }

    private Animator animator;

    private GameStateController gameStateController;

    #region STATES
    private int patrolState;
    private int attackState;
    #endregion

    private void Awake()
    {
        InitStates();
        gameStateController = FindObjectOfType<GameStateController>();
    }

    private void InitStates()
    {
        patrolState = Animator.StringToHash("Patrol");
        attackState = Animator.StringToHash("Attack");
    }

    private void OnEnable()
    {
        gameStateController.OnGameStarted += Patrol;
    }

    private void OnDisable()
    {
        gameStateController.OnGameStarted -= Patrol;
    }

    public void Patrol()
    {
        Animator.SetTrigger(patrolState);
    }

    public void Attack()
    {
        Animator.SetTrigger(attackState);
    }
}
