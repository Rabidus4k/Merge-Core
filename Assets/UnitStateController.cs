using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : MonoBehaviour
{
    [SerializeField]
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
        animator.SetTrigger(patrolState);
    }

    public void Attack()
    {
        animator.SetTrigger(attackState);
    }
}
