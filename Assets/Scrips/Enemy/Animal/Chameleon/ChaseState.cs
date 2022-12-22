using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Jobs;

public class ChaseState : StateMachineBehaviour
{
    Transform target;
    public float speed = 2f;
    Transform borderCheck;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lay doi tuong GameObj
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //Lay thanh phan dung getcomponet<ten Scrip>().doi toong can lay
        borderCheck = animator.GetComponent<ZombieLocalScale>().borderCheck;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 1.5f)
        {
            animator.SetBool(("Bool_isAttack"), true);
        }
            Vector2 newPos = new Vector2(target.position.x, animator.transform.position.y);
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);
        
       // Physics2D.Raycast: ban ra 1 tia trong khong gian, phat hien va cham co length = distance
        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 1) == false)
        {
            animator.SetBool("Bool_isChasing", false);
        }
        
    }

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
}
