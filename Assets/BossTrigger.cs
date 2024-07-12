using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject boss; // Reference to the boss game object
    private Animator bossAnimator;
    public Canvas bossHPcanvas;
    private bool activated = false;

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
        if (!activated) 
        {
            Debug.Log("Boss is not activated, activating the boss...");
            // Check if the player enters the trigger area
            if (other.CompareTag("Player"))
            {
                // Activate the boss
                if (boss != null)
                {
                    bossHPcanvas.enabled = true;
                    boss.SetActive(true);
                    bossAnimator.SetTrigger("Start");
                    activated = true;
                }
            }
        }
        else 
        {
            Debug.Log("Boss is already activated.");
        }
    }
}

