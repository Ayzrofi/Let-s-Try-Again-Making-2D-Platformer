using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour {
    public Animator animatorController;
    public Rigidbody2D MyBody;
    public float JumpHigh;
    public bool IsGrounded;
    public bool doubleJump;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    //public float wallPushJumpForce;
    //public float wallJumpForce;
    //public bool InTheWall;
    //public Transform WallCheck;
    //public float WallCheckRadius;
    //public LayerMask WhatIsWall;

    private void Start()
    {
        if (MyBody == null)
            MyBody = GetComponent<Rigidbody2D>();
        
        if (animatorController == null)
            animatorController = GetComponent<Animator>();
    }
    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //InTheWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

        if (IsGrounded)
        {
            doubleJump = false;
        }

        if (IsGrounded && Input.GetKeyDown(KeyCode.Space) || !doubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            doubleJump = true;
        }

        animatorController.SetFloat("Jump", MyBody.velocity.y);
        //if (Input.GetKeyDown(KeyCode.Space) && InTheWall)
        //{
        //    //MyBody.velocity = new Vector2(wallPushJumpForce, wallJumpForce);
        //    if (!PlayerMovement.facingRight)
        //    {
        //        MyBody.AddForce(new Vector2(wallPushJumpForce, wallJumpForce));
        //    } else 
        //    if (PlayerMovement.facingRight)
        //    {
        //        MyBody.AddForce(new Vector2(-wallPushJumpForce, wallJumpForce));
        //    }

        //    Jump();
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
        //Gizmos.DrawWireSphere(WallCheck.position, WallCheckRadius);
    }

    public void Jump()
    {

        MyBody.velocity = Vector2.up * JumpHigh;
        
        //GetPlayerPrefbs.SaveGame();
    }

    public void AndroidJump()
    {
        if (IsGrounded || !doubleJump)
        {
            Jump();
            doubleJump = true;
            
        }
            
    }
}
