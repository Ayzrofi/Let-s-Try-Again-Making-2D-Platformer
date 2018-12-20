using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndroid : MonoBehaviour {
    [Header("Movement Controll")]
    public Rigidbody2D Rb;
    public float MoveSpeed;
    [Header("Knock Back Controll")]
    public float knockBackForce;
    public float knockBackCounter;
    [HideInInspector]
    public float curKnockBackCounter;
    [HideInInspector]
    public bool enemyInRightDirection;
    [SerializeField]
    private Animator Anim;

    private float Dir;
    public bool IsMoving;
    public bool IsAttacking;
    public static bool FacingRight;

    private void Awake()
    {
        FacingRight = false;
        if (Rb == null)
            Rb = GetComponent<Rigidbody2D>();
        //if (P_Jump == null)
        //    P_Jump = GetComponent<PlayerJump>();
    }
    private void FixedUpdate()
    {
        if (curKnockBackCounter <= 0)
        {
            if (IsMoving && !IsAttacking)
                Rb.velocity = new Vector2(Dir * MoveSpeed, Rb.velocity.y);
            else
                Rb.velocity = new Vector2(0, Rb.velocity.y);
        }
        else
        {
            if (enemyInRightDirection)
                Rb.velocity = new Vector2(-knockBackForce, knockBackForce );
            else
                Rb.velocity = new Vector2(knockBackForce, knockBackForce );

            curKnockBackCounter -= Time.deltaTime;
        }
        
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        MeleAttack();
    //    }
    //}
    public void MeleAttack()
    {
        Anim.SetTrigger("Attack");
        Debug.Log("aaaa");
    }
    public void Movement(float Direction)
    {
        Dir = Direction;

        //if (Dir > 0)
        //{
        //    var Scale = transform.localScale;
        //    Scale.x = transform.localScale.x * 1;
        //    transform.localScale = Scale;
        //}
        //else
        //if (Dir < 0)
        //{
        //    var Scale = transform.localScale;
        //    Scale.x = transform.localScale.x * -1;
        //    transform.localScale = Scale;
        //}
        if (Dir > 0 && FacingRight || Dir < 0 && !FacingRight)
        {
            FacingRight = !FacingRight;

            var Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }

        IsMoving = true;
        //Debug.Log(IsMoving);
        Anim.SetFloat("IsRunning", Mathf.Abs(Dir));
    }
    public void StopMovement()
    {
        Dir = 0;
        Anim.SetFloat("IsRunning", Mathf.Abs(Dir));
        IsMoving = false;
        //Debug.Log(IsMoving);
    }
    public void StopMovingForDoingAttack()
    {
        Dir = 0;
        IsAttacking = true;
        IsMoving = false;
        Anim.SetFloat("IsRunning", Mathf.Abs(Dir));
    }

    public void StopAttacking()
    {
        IsAttacking = false;
        IsMoving = true;
        //Anim.SetFloat("IsRunning", Mathf.Abs(Dir));
    }
    //public void Jump()
    //{
    //    P_Jump.Jump();
    //}
}
