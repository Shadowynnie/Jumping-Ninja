using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int coinValue = 1;
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hits the coin.");
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject); // Destroy the coin object
                player.Gather(coinValue, 0, 0);
            }

        }
    }
}
