using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerBoxCollider;
    public CircleCollider2D playerCircleCollider;
    private Vector2 checkPointPosition;
    //public Rigidbody2D playerRb;

    public int maxHealth = 100;
    private int currentHealth;
    public int level = 1;

    public int coinCount = 0;
    public Text coinCountText;
    public int shurikenCount = 0;
    public Text shurikenCountText;
    public Text alertText;
    //private int deathCount = 0;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        checkPointPosition = new Vector2(-10,1f);
        //playerRb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        UpdateCoinUI();
        UpdateShurikenUI();
    }

    // The player takes damage
    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) // Player cannot take damage if he is dead
        {
            return;
        }
        // Play some damage/hurt player animation
        animator.SetTrigger("IsHurt");

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) // If the player's health drops to 0 or less, dies...
        {
            Die();
        }
    }

    // Dying logic of the player and playing some dying animation
    void Die()
    {
        Debug.Log("Died");

        // Play some dying animation
        animator.SetBool("Dead", true);

        // Show Game over with some menu...
        // TODO: The Die() function is called more than once when the player is killed, solve it
        //if(deathCount >= 2) 
        //{
        //    alertText.text = "GAME OVER";
        //    Invoke(nameof(ClearAlertUI),3f);
        //    FindObjectOfType<GameManager>().GameOver();
        //}
        //else 
        //{
        //    Invoke("Respawn", 3f);
        //    deathCount++;
        //    Debug.Log("DeathCount: " + deathCount);
        //}

        Invoke("Respawn", 3f);
        //StartCoroutine(Respawn(0.5f));
    }

    public void Gather(int coins = 0, int shurikens = 0, int hearts = 0)
    {
        if (coins > 0) 
        {
            coinCount += coins;
            UpdateCoinUI();
        }
        if (shurikens > 0) 
        {
            shurikenCount += shurikens;
            UpdateShurikenUI();
        }
        if (hearts > 0) 
        {
            if((currentHealth+hearts) > maxHealth) 
            {
                currentHealth = maxHealth;
            }
            else 
            {
                currentHealth += hearts;
            }
            healthBar.SetHealth(currentHealth);
        }
    }

    public void UpdateCoinUI()
    {
        coinCountText.text = coinCount.ToString();
    }

    public void UpdateShurikenUI() 
    {
        shurikenCountText.text = shurikenCount.ToString();
    }

    public void UpdateCheckPoint(Vector2 position) 
    {
        checkPointPosition = position;
    }

    public void Respawn() 
    {
        transform.position = checkPointPosition;
        animator.SetBool("Dead", false);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public void ClearAlertUI() 
    {
        alertText.text = "";
    }

    public float[] GetCheckPointPos() 
    {
        float[] pos = new float[2];
        pos[0] = checkPointPosition.x;
        pos[1] = checkPointPosition.y;
        return pos;
    }

    public void SetCheckPointPos(Vector2 pos) 
    {
        checkPointPosition = pos;
    }
}
