using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Player player;
    public Transform respawnPoint;
    public Animator animator;
    Collider2D checkPointCollider;
    bool isChecked = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        checkPointCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isChecked) 
        {
            if (collision.CompareTag("Player"))
            {
                isChecked = true;
                // Update the position of the checkpoint
                player.UpdateCheckPoint(respawnPoint.position);
                animator.SetBool("Checked", isChecked);
                checkPointCollider.enabled = false;
                FindObjectOfType<GameManager>().SaveGame(player);
            }
        }
    }
}
