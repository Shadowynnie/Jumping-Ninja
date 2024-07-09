using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 20;
    public float attackRange = 0.5f;
    public float attackCooldown = 1f;
    public LayerMask playerLayer;

    private float lastAttackTime;

    void Update()
    {
        // Check if it's time to attack again
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Detect player in attack range
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
        if (playerCollider != null)
        {
            // Deal damage to the player
            playerCollider.GetComponent<Player>().TakeDamage(attackDamage);
            lastAttackTime = Time.time;
            Debug.Log("The player was attacked by the enemy.");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a circle in the editor to show the attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

