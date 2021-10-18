using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int maxHealth = 30;
    public Animator anim;
    public int currHealth = 0;
    private SpriteRenderer sprite;
    [SerializeField] public Transform player;
    //[SerializeField] public EnemyHP hpBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        //hpBar.SetHealth(currHealth,maxHealth);
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
        //hpBar.SetHealth(currHealth,maxHealth);
        anim.SetTrigger("Hurt");
        if (currHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        anim.SetBool("hasDied",true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
}
