using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
   public int maxHealth = 30;
       public Animator anim;
       private int currHealth;
       private SpriteRenderer sprite;
       [SerializeField] private float sightRange = 10f;
       [SerializeField] public Transform player;
       
       // Start is called before the first frame update
       void Start()
       {
           currHealth = maxHealth;
           sprite = GetComponent<SpriteRenderer>();
       }
   
       public void FacePlayer()
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
       public void TakeDamage(int amount)
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

       public void Death()
       {
           anim.SetBool("hasDied",true);
           GetComponent<Collider2D>().enabled = false;
           this.enabled = false;
           
       }
}
