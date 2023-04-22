using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorAnimation : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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

    [SerializeField]
    private float tiempobreaker;
    private bool isbreaking;
    float speed;
    private float idleTiempo;

    private void Awake()
    {
        
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        speed = animator.speed;

        isbreaking = false;
        idleTiempo = 0;
        animator.SetFloat("breaker", 0);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isbreaking == false)
        {
            idleTiempo+= Time.deltaTime;
            if (idleTiempo > tiempobreaker  )
            {
                
                Debug.Log("breaker");
                isbreaking = true;
                animator.SetFloat("breaker", 1);
            }
        }
        else if(stateInfo.normalizedTime %1> 0.91)
        {
            ResetIdle(animator);
        }
    }
    private void ResetIdle(Animator animator)
    {
        animator.speed = speed;
        isbreaking = false;
        idleTiempo = 0;
        animator.SetFloat("breaker", 0);
    }
}
