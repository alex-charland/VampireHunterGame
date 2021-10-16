using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool isAttacking = false;
    [SerializeField] private Collider2D enemyCollider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            isAttacking = true;
        }
    }
}
