using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int weaponDamage = 45;
    public float attackSpeed = 2f;
    private float attackNext = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= attackNext) 
        {
            if (Input.GetButtonDown("Fight"))
            {
                Attack();
                attackNext = Time.time + 1f / attackSpeed;
            }
        }
    }

    void Attack() 
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Detect all enemies in the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // Physics2D.OverlapCircleAll() creates a circle from a specified point and collects all object hit by the circle

        // Deal damage to the enemies
        // To damage all enemies, we have to loop through them all
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            Enemy enemy = hitEnemies[i].GetComponent<Enemy>();
            Boss boss = hitEnemies[i].GetComponent<Boss>();

            if (enemy != null) 
            {
                enemy.TakeDamage(weaponDamage);
            }
            if(boss != null) 
            {
                boss.TakeDamage(weaponDamage);
            }

            Debug.Log("We hit " +  hitEnemies[i].name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null) 
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
