using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] public int maxHealth = 60;
    public Animator anim;
    private int currHealth;
    [SerializeField] public Slider hpbar;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        hpbar.maxValue = maxHealth;
        hpbar.value = currHealth;
    }
    
    public void TakeDamage(int amount)
    {
        currHealth -= amount;
        hpbar.value = currHealth;
        anim.SetTrigger("Hurt");
        if (currHealth <= 0)
        {
            Death();
        }
    }

    public void SetHP(int amount)
    {
        currHealth += amount;
        hpbar.value = currHealth;
    }
    public void Death()
    {
        anim.SetBool("hasDied",true);
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        

    }
}
