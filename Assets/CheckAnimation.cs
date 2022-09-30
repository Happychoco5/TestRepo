using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimation : StateMachineBehaviour
{
    [Serializable]
    public struct animStatesToChange
    {
        public string boolName;
        public bool boolToChange;
    }

    public animStatesToChange[] animStates;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //blobby.inAir = true;
        //gameObject.GetComponent<Blobby>().inAir = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.gameObject.GetComponent<Blobby>().inAir = true;
        //animator.SetBool("canJump", false);
        //animator.SetBool("jumped", true);
        //Debug.Log(animator.GetBool("canJump"));"
        ChangeAnimatorBoolStatesOnExit(animator);

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

    void ChangeAnimatorBoolStatesOnExit(Animator anim)
    {
        for (int i = 0; i < animStates.Length; i++)
        {
            anim.SetBool(animStates[i].boolName, animStates[i].boolToChange);
        }
    }
}
