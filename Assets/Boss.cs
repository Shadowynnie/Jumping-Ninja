using System.Collections;
using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public BossAttack bossAttack;
    public GameObject deathEffect;

    public bool isFlipped = false;
    public int maxHealth = 1000;
    private int currentHealth;
    public static float movementSpeed = 1f;

    public BossHealthBar bossHealthBar;
    //public Canvas bossHPcanvas;
    Victory victory;

    private void Start()
    {
        bossAttack = GetComponent<BossAttack>();
        victory = FindAnyObjectByType<Victory>();
        currentHealth = maxHealth;
        bossHealthBar.SetMaxHealth(maxHealth);
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void StartShootingCoroutine()
    {
        StartCoroutine(bossAttack.ShootRasenganSequence());
    }

    // The enemy takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        bossHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) // If enemy's health drops to 0 or less, dies...
        {
            victory.ShowVictoryBanner();
            Die();
        }
    }

    // Dying logic of the enemy and playing some dying animation
    void Die()
    {
        // Creates an instance of a death effect
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("Boss dies...");
        // Destroy the enemy game object (enemy disappears)
        Destroy(gameObject);
    }
}
