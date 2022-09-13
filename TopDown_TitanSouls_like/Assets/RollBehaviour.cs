using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBehaviour : StateMachineBehaviour
{
    // Unity does not allow yet to slide the Movement script into the public field via the inspector
    // we need to retrieve manually first the Movement script the GameObject via Script 
    // then we retrieve the Player Game Object via GetComponent

    public CharacterStateMachine CharacterStateMachine;
    

    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("start roll animation state");
        animator.gameObject.GetComponent<Movement>()._isControllable = false; // switch off controls for player
        animator.gameObject.GetComponent<Movement>().currentSpeed = animator.gameObject.GetComponent<Movement>()._runSpeed;
        CharacterStateMachine._playerMovement._isControllable = false; 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("end roll animation state");
        CharacterStateMachine._playerMovement._isControllable = true; // switch player controls back on
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
