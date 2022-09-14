using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBehaviour : StateMachineBehaviour
{

    private Movement _playerMovement;
    
    //look for PlayerRig, so we can use it later with the animator
    private void Awake()
    {
        _playerMovement = GameObject.Find("PlayerRig").GetComponent<Movement>();
        
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("start roll animation state");
        
        _playerMovement._isControllable = false;
        _playerMovement._currentSpeed = _playerMovement._rollSpeed;
    }

    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("end roll animation state");
        _playerMovement._isControllable = true; // switch player controls back on
        animator.SetBool("isRolling", false); // deactivate rolling animation
    }

 
}
