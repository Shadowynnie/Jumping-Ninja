using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject deathEffect;
    public EnemyHealthBar enemyHealthBar;
    public Canvas enemyHPcanvas;

    private void Start()
    {
        enemyHPcanvas.enabled = false;
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    // The enemy takes damage
    public void TakeDamage(int damage)
    {
        enemyHPcanvas.enabled = true;
        currentHealth -= damage;
        enemyHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) // If enemy's health drops to 0 or less, dies...
        {
            Die();
        }
    }

    // Dying logic of the enemy and playing some dying animation
    void Die()
    {
        // Creates an instance of a death effect
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        // Destroy the enemy game object (enemy disappears)
        Destroy(gameObject);
    }
}
