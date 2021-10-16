using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerrb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float xDir = 0f;

    [SerializeField] private float moveSpeed = 5f;
    
    private enum MovementState{idle,running,jumping,falling}

    private MovementState state = MovementState.idle;
    // Start is called before the first frame update
    private void Start()
    {
        playerrb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            playerrb.velocity = new Vector2(playerrb.velocity.x,moveSpeed);
        }
        playerrb.velocity = new Vector2(xDir * moveSpeed,playerrb.velocity.y);
        AnimationChange();
    }

    private void AnimationChange()
    {
        MovementState state;
        if (xDir > 0f)
        {
            //anim.SetBool("Running",true);
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(xDir < 0f)
        {
            //anim.SetBool("Running", true);
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            //anim.SetBool("Running",false);
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
}
