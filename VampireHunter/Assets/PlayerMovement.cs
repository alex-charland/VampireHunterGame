using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerrb;
    private BoxCollider2D playerbc;
    private SpriteRenderer sprite;
    private Animator anim;
    private float xDir = 0f;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private LayerMask groundlayer;
    
    private enum MovementState{idle,running,jumping,falling}

    private MovementState state = MovementState.idle;
    // Start is called before the first frame update
    private void Start()
    {
        playerrb = GetComponent<Rigidbody2D>();
        playerbc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerrb.velocity = new Vector2(playerrb.velocity.x,moveSpeed);
        }

        //if (Input.GetKeyDown(KeyCode.F) && IsGrounded())
        //{
            //AttackMode();
        //}
        playerrb.velocity = new Vector2(xDir * moveSpeed,playerrb.velocity.y);
        AnimationChange();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerbc.bounds.center, playerbc.bounds.size,0f,Vector2.down,0.1f,groundlayer);
    }
    private void AnimationChange()
    {
        MovementState state;
        if (xDir > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(xDir < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (playerrb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (playerrb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("State",(int)state);
    }

    //private void AttackMode()
    //{
    //    anim.SetTrigger("Attack");
    //}

    
}
