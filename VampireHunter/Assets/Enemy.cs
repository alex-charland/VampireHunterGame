using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void FacePlayer();
    public abstract void TakeDamage(int amount);
    public abstract void Death();
    protected SpriteRenderer sprite;
    protected int currHealth;
    protected int maxHealth;
}
