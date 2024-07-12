using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject ShurikenPrefab;
    public Animator animator;
    public Player player;

    void Start()
    {
        // Find the Player component in the scene
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Player component not found in the scene. Please ensure there is a GameObject tagged 'Player' with a Player component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Throw"))
        {
            if (player.shurikenCount > 0) 
            {
                TriggerThrow();
            }
            else 
            {
                Debug.Log("Not enough shurikens.");
                player.alertText.text = "Not enough shurikens.";
                Invoke(nameof(ClearAlert), 2f);
            }     
        }
    }

    void TriggerThrow()
    {
        // Trigger the throw animation
        animator.SetTrigger("Throw");
    }

    // This method will be called by an animation event
    public void Shoot()
    {
        // Throwing/Shooting shuriken logic
        Instantiate(ShurikenPrefab, throwPoint.position, throwPoint.rotation);
        player.shurikenCount--;
        player.UpdateShurikenUI();
    }

    private void ClearAlert()
    {
        player.ClearAlertUI();
    }
}

