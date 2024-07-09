using UnityEngine;

public class ShurikenCollectible : MonoBehaviour
{
    public int shurikensCount = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player has gathered a shuriken.");
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject); // Destroy the shuriken collectible object
                player.Gather(0, shurikensCount, 0);
            }
        }
    }
}
