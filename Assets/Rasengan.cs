using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rasengan : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public int bulletDamage = 40;
    public Rigidbody2D rigidBody;
    public GameObject impactEffect;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(bulletDamage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Debug.Log(hitInfo);
        Destroy(gameObject); // Destroy the bullet/rasengan when it hits something...
    }
}

