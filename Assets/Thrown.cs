using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject ShurikenPrefab;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Throw"))
        {
            TriggerThrow();
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
    }
}

