using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update


    public CharacterController2D controller;
    public Animator animator; 

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //getting the input raw for use in FixedUpdate
        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }


    }

    private void FixedUpdate()
    {
        // Movment for the Charachter (Movemnent Crouch Jump)
        controller.Move(horizontalMove *Time.fixedDeltaTime, false, jump);
        jump = false;

    }

    public void OnLanding ()
    {
        animator.SetBool("isJumping", false);
    }

}
