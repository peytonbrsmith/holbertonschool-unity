using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : StateMachineBehaviour
{
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     Debug.Log("Animation has started!");
    // }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     Debug.Log("Animation is playing!");
    // }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     Debug.Log("Animation has exited!");
    //     GameObject self = animator.gameObject;
    //     self.SetActive(false);
    // }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    // override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     Debug.Log("Animation is moving!");
    // }

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    // override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     Debug.Log("Animation is IK!");
    // }

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    // override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    // {
    //     Debug.Log("Animation has entered a state machine!");
    // }

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("Animation has ended!");
        animator.SetBool("running",false);
    }
}
