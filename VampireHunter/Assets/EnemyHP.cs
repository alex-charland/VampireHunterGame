using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider hpbar;

    public Vector3 heightOffset;

    // Update is called once per frame
    public void Update()
    {
        hpbar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + heightOffset);
    }

    public void SetHealth(int amount, int maxHealth)
    {
        hpbar.gameObject.SetActive(amount < maxHealth);
        hpbar.maxValue = maxHealth;
        hpbar.value = amount;
    }
}
