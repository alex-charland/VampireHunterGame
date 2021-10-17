using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private bool attackMode;
    private bool attackStarted, isAttacking, isFirstAttack;
    [SerializeField] private float inputTimer, attack1Radius, attack1Damage;
    private float attackStartTime = Mathf.Infinity;
    private Animator anim;
    [SerializeField] private Transform attack1Bounds;
    [SerializeField] private LayerMask damageableLayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack",attackMode);
        isFirstAttack = false;
    }

    private void Update()
    {
        CheckAttackMode();
        CheckAttacks();
    }

    private void CheckAttackMode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (attackMode)
            {
                //Do combat
                attackStarted = true;
                attackStartTime = Time.time;
            }
        }
    }

    private void CheckAttacks()
    {
        if (attackStarted)
        {
            if (!isAttacking)
            {
                attackStarted = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                anim.SetBool("attack1",true);
                anim.SetBool("firstAttack",isFirstAttack);
                anim.SetBool("isAttacking",isAttacking);
            }
        }

        if (Time.time >= attackStartTime + inputTimer)
        {
            attackStarted = false;
        }
    }

    private void CheckAttackHit()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(attack1Bounds.position,attack1Radius,damageableLayer);
        foreach (Collider2D collider in objectsInRange)
        {
            collider.transform.parent.SendMessage("Damage",attack1Damage);
        }
    }

    private void ExitAttack1()
    {
        isAttacking = false;
        anim.SetBool("isAttacking",isAttacking);
        anim.SetBool("attack1", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1Bounds.position,attack1Radius);
    }
}
