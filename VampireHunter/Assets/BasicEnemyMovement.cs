using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D enemyrb;
    private BasicEnemy enemy;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float attackRange = 1f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyrb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<BasicEnemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.FacePlayer();
        Vector2 target = new Vector2(player.position.x, enemyrb.position.y);
        Vector2 targetPos = Vector2.MoveTowards(enemyrb.position, target, speed * Time.fixedDeltaTime);
        enemyrb.MovePosition(targetPos);
        if (Vector2.Distance(player.position, enemyrb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
