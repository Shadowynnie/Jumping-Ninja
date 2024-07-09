using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject boss; // Reference to the boss game object
    private Animator bossAnimator;
    public Canvas bossHPcanvas;

    void Start()
    {
        // Ensure the boss is inactive at the start
        if (boss != null)
        {
            bossHPcanvas.enabled = false;
            bossAnimator = boss.GetComponent<Animator>();
            boss.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger area
        if (other.CompareTag("Player"))
        {
            // Activate the boss
            if (boss != null)
            {
                bossHPcanvas.enabled = true;
                boss.SetActive(true);
                bossAnimator.SetTrigger("Start");
            }
        }
    }
}

