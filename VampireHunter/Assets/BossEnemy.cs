using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    public Animator anim;
    [SerializeField] private float sightRange = 10f;
       [SerializeField] public Transform player;
       
       // Start is called before the first frame update
       void Start()
       {
           maxHealth = 100;
           currHealth = maxHealth;
           sprite = GetComponent<SpriteRenderer>();
       }
   
       public override void FacePlayer()
       {
           if (transform.position.x > player.position.x)
           {
               sprite.flipX = true;
           }
           else
           {
               sprite.flipX = false;
           }
       }
       public override void TakeDamage(int amount)
       {
           currHealth -= amount;
           anim.SetTrigger("Hurt");
           if (currHealth <= 0)
           {
               Death();
           }
       }

       public void FixedUpdate()
       {
           RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, sightRange);
           if (hit)
           {
               if (hit.collider.CompareTag("Player"))
               {
                   anim.SetBool("playerSighted", true);
                   Debug.Log("player sighted");
               }
           }
       }

       public override void Death()
       {
           anim.SetBool("hasDied",true);
           GetComponent<Collider2D>().enabled = false;
           this.enabled = false;
           FindObjectOfType<GameManager>().WinGame();
           
       }
}
