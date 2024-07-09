using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int healthValue = 25;
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hits the heart.");
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject); // Destroy the heart object
                player.Gather(0, 0, healthValue);
            }

        }
    }
}
