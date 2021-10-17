using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   private enum MovementState
   {
      walking,
      hit,
      attack,
      dead
   }

   private MovementState state;
   private bool groundDetected;
   private bool wallDetected;
   private SpriteRenderer sprite;
   private Rigidbody2D enemyrb;
   private Animator anim;
   private float xDir = 0f;
   [SerializeField] private Transform groundCheck;

   [SerializeField] private Transform wallCheck;

   [SerializeField] private LayerMask groundLayer;

   [SerializeField] private float groundCheckDistance;

   [SerializeField] private float wallCheckDistance;
   [SerializeField] private float moveSpeed = 5f;

   private void Start()
   {
      sprite = GetComponent<SpriteRenderer>();
      enemyrb = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
   }

   //Walking State
   private void EnterWalkingState()
   {
      anim.SetInteger("State",(int)MovementState.walking);
   }

   private void UpdateWalkingState()
   {
      xDir = Input.GetAxisRaw("Horizontal");
      groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
      wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, groundLayer);
      if (!groundDetected || wallDetected)
      {
         Flip();
      }
      else
      {
         enemyrb.velocity = new Vector2(xDir * moveSpeed,enemyrb.velocity.y);
      }
   }
   private void ExitWalkingState()
   {
      
   }
   //Hit State
   private void EnterHitState()
   {
      
   }

   private void UpdateHitState()
   {
      
   }
   private void ExitHitState()
   {
      
   }
   //Attack State
   private void EnterAttackState()
   {
      
   }

   private void UpdateAttackState()
   {
      
   }
   private void ExitAttackState()
   {
      
   }
   //Dead State
   private void EnterDeadState()
   {
      
   }

   private void UpdateDeadState()
   {
      
   }
   private void ExitDeadState()
   {
      
   }
   private void Update()
   {
      switch (state)
      {
         case MovementState.walking:
            UpdateWalkingState();
            break;
         case MovementState.hit:
            UpdateHitState();
            break;
         case MovementState.attack:
            UpdateAttackState();
            break;
         case MovementState.dead:
            UpdateDeadState();
            break;
      }
   }

   private void ChangeState(MovementState nextState)
   {
      switch (state)
      {
         case MovementState.walking:
            ExitWalkingState();
            break;
         case MovementState.hit:
            ExitHitState();
            break;
         case MovementState.attack:
            ExitAttackState();
            break;
         case MovementState.dead:
            ExitDeadState();
            break;
      }
      switch (nextState)
      {
         case MovementState.walking:
            EnterWalkingState();
            break;
         case MovementState.hit:
            EnterHitState();
            break;
         case MovementState.attack:
            EnterAttackState();
            break;
         case MovementState.dead:
            EnterDeadState();
            break;
      }

      state = nextState;
   }

   private void Flip()
   {
      sprite.flipX = !sprite.flipX;
   }
}
