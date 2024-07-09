using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public int bulletDamage = 30;
    public Rigidbody2D rigidBody;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        // Bullet movement logic
        rigidBody.velocity = transform.right * bulletSpeed;
        /* velocity is the current speed of the rigid body on the three axis
         * 
         */
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Boss boss = hitInfo.GetComponent<Boss>();


        if (enemy != null) 
        {
            enemy.TakeDamage(bulletDamage);
        }

        if (boss != null) 
        {
            boss.TakeDamage(bulletDamage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        //Debug.Log(hitInfo); // To write out the info about the object we hit with the bullet/shuriken
        Destroy(gameObject); // Destroy the bullet/shuriken when it hits something
    }
}
