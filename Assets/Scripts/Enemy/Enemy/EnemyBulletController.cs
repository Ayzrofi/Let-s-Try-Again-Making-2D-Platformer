using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBulletController : MonoBehaviour {
    public int Speed;
    public Rigidbody2D Rb;
    private void Start()
    {
        Destroy(this.gameObject, 3f);

        if (Rb == null)
            Rb = GetComponent<Rigidbody2D>();

        //if (!EnemyController.FacingRight)
        //    Speed = -Speed;
    }
    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(Speed, Rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
