using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBehaviour : StateMachineBehaviour
{

    public CharacterStateMachine CharacterStateMachine;
    
       
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("start roll animation state");
        Movement _playerMovement = animator.gameObject.GetComponent<Movement>();
        _playerMovement._isControllable = false;
        _playerMovement._currentSpeed = _playerMovement._rollSpeed;
    }

    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("end roll animation state");
        animator.gameObject.GetComponent<Movement>()._isControllable = true; // switch player controls back on
    }

 
}
