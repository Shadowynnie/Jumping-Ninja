using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D charController;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool crouch = false;
    bool jump = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //charController.Move();
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // Debug.Log() nám vypisuje v unity konzoli. takze neco jako Console.WriteLine() nebo console.log(), dobre na debugging

        // Animation control
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // Mathf.Abs gives the absolute value, because the Speed value has to be positive

        // Key control
        // Jumping
        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        // Crouching
        if (Input.GetButtonDown("Crouch")) 
        {
            crouch = true;
            //Debug.Log("Crouched.");
        }
        else if (Input.GetButtonUp("Crouch")) 
        {
            crouch = false;
        }
    }

    public void OnLanding() 
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool IsCrouching) 
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    private void FixedUpdate()
    {
        // Move the player character
        charController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
