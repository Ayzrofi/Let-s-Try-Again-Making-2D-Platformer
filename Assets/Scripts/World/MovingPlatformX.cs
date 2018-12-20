using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformX : MonoBehaviour {
    //float dirX;
    [SerializeField]
    float MoveSpeed;
    [SerializeField]
    Transform minX, maxX;
    Rigidbody2D rb;
    [SerializeField]
    bool MoveToRight;
    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        //MoveSpeed = -1;
    }

    private void Update()
    {
         if (transform.position.x <= minX.transform.position.x)
            MoveToRight = true;
        else
         if (transform.position.x >= maxX.transform.position.x)
            MoveToRight = false;

        //if (transform.position.x < minX)
        //    transform.position = new Vector2(transform.position.x + MoveSpeed * Time.deltaTime, transform.position.y);
        ////else 
        ////if (transform.position.x > maxX)
        ////    transform.position = new Vector2(transform.position.x - MoveSpeed * Time.deltaTime, transform.position.y);
    }
    private void FixedUpdate()
    {
        if (/*transform.position.x >= minX.transform.position.x && */MoveToRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, maxX.position, MoveSpeed * Time.deltaTime);
        }
        else
        if (/*transform.position.x <= maxX.transform.position.x && */!MoveToRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, minX.position, MoveSpeed * Time.deltaTime);
        }
        //transform.position = new Vector2(transform.position.x + MoveSpeed * Time.deltaTime, transform.position.y);
        //rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.SetParent(this.transform);
            Debug.Log("You Know is Very Shit");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.SetParent(null);
            Debug.Log("Asuu Loe Kentod");
        }
    }
}
