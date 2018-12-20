using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D MyBody;
    public float MoveSpeed;
    float MoveInput;
    public PlayerJump pJump;
    public static bool facingRight ;
   


    private void Start()
    {
        if (MyBody == null)
        {
            MyBody = GetComponent<Rigidbody2D>();
        }
    }
    private void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
        if (MoveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }
        else if(MoveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }
            
      
    }
    private void FixedUpdate()
    {
        //if (!pJump.InTheWall)
        //{
        //    MyBody.velocity = new Vector2(MoveInput * MoveSpeed, MyBody.velocity.y);
        //}
               
    }

}
