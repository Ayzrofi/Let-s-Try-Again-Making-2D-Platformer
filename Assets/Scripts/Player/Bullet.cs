using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //public int Speed;
    public Rigidbody2D Rb;

    private void Start()
    {
        //if (InputAndroid.FacingRight)
        //    Speed = -Speed;
        Destroy(gameObject,1.5f);
    }
    //private void FixedUpdate()
    //{
    //    Rb.velocity = new Vector2(Speed, Rb.velocity.y);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
