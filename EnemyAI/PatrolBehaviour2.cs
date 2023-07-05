using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour2 : StateMachineBehaviour
{
    float timer;
    List<Transform> WayPoints2 = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float ChaseRange = 20;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform WayPointsObject = GameObject.FindGameObjectWithTag("WayPoints2").transform;
        foreach (Transform t in WayPointsObject)
            WayPoints2.Add(t);

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(WayPoints2[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(WayPoints2[Random.Range(0, WayPoints2.Count)].position);
        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("IsPatroling", false);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < ChaseRange)
            animator.SetBool("IsChasing", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }

}
