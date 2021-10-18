using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    [SerializeField] private PlayerHP playerhp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HPItem"))
        {
            playerhp.SetHP(10);
            Destroy(other.gameObject);
        }
    }
}
