﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get inputs
        ProcessInputs();

        //animate
        Animate();
    }

    //handles physics better
    private void FixedUpdate()
    {
        //move
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));    
        }
        isJumping = false;

    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); //scale of -1 to 1

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
