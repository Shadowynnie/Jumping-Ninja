using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int attackDamage = 20;
    public int rasenganDamage = 40;
    public float attackRange = 1f;
    public float shootDelay = 0.5f; // Delay between each Rasengan shot in the sequence

    public Vector3 attackOffset;
    public LayerMask attackMask;
    public Transform attackPoint; // For melee attack
    public Transform firePoint; // For Rasengan
    public GameObject rasenganPrefab; // Prefab of the Rasengan bullet

    public void Attack()
    {
        Vector3 pos = attackPoint.position;
        pos += attackPoint.right * attackOffset.x;
        pos += attackPoint.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }

    public IEnumerator ShootRasenganSequence()
    {
        for (int i = 0; i < 3; i++)
        {
            ShootRasengan(); // Shoot a Rasengan
            yield return new WaitForSeconds(shootDelay); // Wait for the delay before shooting the next one
        }
    }

    public void ShootRasengan()
    {
        // Instantiate the Rasengan projectile and set its direction
        GameObject rasengan = Instantiate(rasenganPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = rasengan.GetComponent<Rigidbody2D>();
        Vector2 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - firePoint.position).normalized;
        rb.velocity = direction * rasengan.GetComponent<Rasengan>().bulletSpeed;
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = attackPoint.position;
        pos += attackPoint.right * attackOffset.x;
        pos += attackPoint.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
