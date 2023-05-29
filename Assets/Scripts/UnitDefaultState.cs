using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitDefaultState : StateMachineBehaviour
{
    protected UnitStateController stateController;
    protected UnitFindTarget unitFindTarget;
    protected NavMeshAgent navMeshAgent;
    protected BaseAttack baseAttack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateController = animator.transform.root.gameObject.GetComponent<UnitStateController>();
        unitFindTarget = animator.transform.root.gameObject.GetComponent<UnitFindTarget>();
        navMeshAgent = animator.transform.root.gameObject.GetComponent<NavMeshAgent>();
        baseAttack = animator.transform.root.gameObject.GetComponent<BaseAttack>();
    }
}
