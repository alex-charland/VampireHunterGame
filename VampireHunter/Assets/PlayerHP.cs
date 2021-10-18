using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 60;
    public Animator anim;
    private int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
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

    public void Death()
    {
        anim.SetBool("hasDied",true);

    }
}
