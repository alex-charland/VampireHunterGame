using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private float attackRadius;
    private Animator anim;
    [SerializeField] private Transform attackBounds;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int attackValue = 5;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void CheckAttackHit()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(attackBounds.position,attackRadius,playerLayer);
        foreach (Collider2D collider in objectsInRange)
        {
            collider.GetComponent<PlayerHP>().TakeDamage(attackValue);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackBounds.position,attackRadius);
    }
}
