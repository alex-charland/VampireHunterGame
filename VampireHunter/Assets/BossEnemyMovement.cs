using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BossEnemyMovement : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D bossrb;
    private BossEnemy boss;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float attackRange = 3f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossrb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossEnemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("playerSighted"))
        {
            boss.FacePlayer();
            Vector2 target = new Vector2(player.position.x, bossrb.position.y);
            Vector2 targetPos = Vector2.MoveTowards(bossrb.position, target, speed * Time.fixedDeltaTime);
            bossrb.MovePosition(targetPos);
            if (Vector2.Distance(player.position, bossrb.position) <= attackRange)
            {
                animator.SetTrigger("Attack");
            }
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
