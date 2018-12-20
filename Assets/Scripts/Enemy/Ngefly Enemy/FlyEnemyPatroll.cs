using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyPatroll : MonoBehaviour {


    float dirX;
    [SerializeField]
    [Header("Enemy Move Speed")]
    float MoveSpeed;
    [SerializeField]
    float minX, maxX;

    Rigidbody2D rb;
    Vector3 LocalScale;
    // enemy shoot Variabel 
    public  bool FacingRight;
    Quaternion rotations = new Quaternion();

    flyEnemyMovement flyEnemyMove;

    private void Start()
    {
        flyEnemyMove = GetComponent<flyEnemyMovement>();
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        LocalScale = transform.localScale;
        dirX = -1;
    }
    private void Update()
    {
        if (transform.position.x < minX)
            dirX = 1f;
        else if (transform.position.x > maxX)
            dirX = -1f;
    }
    private void FixedUpdate()
    {
        if (/*!flyEnemyMove.IsAttacking ||*/ !flyEnemyMove.PlayerInRange)
        {
            rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);
            rotations.eulerAngles = Vector3.zero;
            transform.rotation = rotations;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


    }
    private void LateUpdate()
    {
        CheckDirections();
    }

    private void CheckDirections()
    {
        FacingRight = (dirX > 0) ? true : false;
        //if (dirX > 0)
        //    FacingRight = true;
        //else if (dirX < 0)
        //    FacingRight = false;
        if (FacingRight && LocalScale.x < 0 || !FacingRight && LocalScale.x > 0)
            LocalScale.x *= -1;
        transform.localScale = LocalScale;
    }
}

