using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimePersistsBetweenStates : StateMachineBehaviour
{

    // Current normalized animation time. Shared among states with this script.
    static float currentNormalizedTime = 0f;

    bool stateReplayed = false;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Re-play the current state using the current animation time.
        if (currentNormalizedTime > 0f && !stateReplayed)
        {
            animator.Play(stateInfo.fullPathHash, layerIndex, currentNormalizedTime);
            stateReplayed = true;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Keep track of the current animation time.
        currentNormalizedTime = stateInfo.normalizedTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateReplayed = false;

        // Reset back to start. 
        // Note that the OnStateEnter of the next state will have already been called so this
        // doesn't affect the next state.
        currentNormalizedTime = 0f;
    }

}
