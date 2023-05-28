using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitDefaultState : StateMachineBehaviour
{
    protected UnitStateController stateController;
    protected UnitFindTarget unitFindTarget;
    protected NavMeshAgent navMeshAgent;
    protected UnitCombat unitCombat;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateController = animator.gameObject.GetComponent<UnitStateController>();
        unitFindTarget = animator.gameObject.GetComponent<UnitFindTarget>();
        navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
        unitCombat = animator.gameObject.GetComponent<UnitCombat>();
    }
}
