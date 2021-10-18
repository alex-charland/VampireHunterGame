using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private BasicEnemy e1;
    [SerializeField] private BasicEnemy e2;

    private void Update()
    {
        if (e1.anim.GetBool("hasDied") && e2.anim.GetBool("hasDied"))
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
