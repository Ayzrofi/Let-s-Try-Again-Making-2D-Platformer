using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyBulletController : MonoBehaviour {
    public float Speed;
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
