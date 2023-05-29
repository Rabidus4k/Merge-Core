using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : UnitDefaultState
{
    private BaseAttack baseAttack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        baseAttack = animator.transform.root.gameObject.GetComponent<BaseAttack>();
        

        navMeshAgent.isStopped = true;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (unitFindTarget.Target == null || Vector3.Distance(animator.transform.position, unitFindTarget.Target.position) > baseAttack.MinDistanceToTarget + 0.5f)
        {
            stateController.Patrol();
            return;
        }
        baseAttack.PerformAttack(unitFindTarget.Target);
        var targetRotation = Quaternion.LookRotation(unitFindTarget.Target.transform.position - animator.transform.position);
        // Smoothly rotate towards the target point.
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, targetRotation, 5 * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
