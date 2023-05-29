using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : UnitDefaultState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        navMeshAgent.enabled = true;
        navMeshAgent.isStopped = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (unitFindTarget.Target == null)
            return;

        navMeshAgent.SetDestination(unitFindTarget.Target.position);
        if (Vector3.Distance(animator.transform.position, unitFindTarget.Target.position) <= baseAttack.MinDistanceToTarget)
        {
            stateController.Attack();
            return;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
