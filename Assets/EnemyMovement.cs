using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy
    public float changeDirectionTime = 2f; // Time in seconds before changing direction

    private float direction = 1f; // 1 for right, -1 for left
    private float timer;

    void Start()
    {
        timer = changeDirectionTime; // Initialize the timer
    }

    void Update()
    {
        // Move the enemy
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Update the timer
        timer -= Time.deltaTime;

        // Check if it's time to change direction
        if (timer <= 0)
        {
            direction *= -1; // Change direction
            FlipSprite(); // Flip the sprite
            timer = changeDirectionTime; // Reset the timer
        }
    }

    void FlipSprite()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip the x scale to mirror the sprite
        transform.localScale = localScale;
    }
}


