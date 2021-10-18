using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform attackBounds;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] public int attackValue = 5;

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
