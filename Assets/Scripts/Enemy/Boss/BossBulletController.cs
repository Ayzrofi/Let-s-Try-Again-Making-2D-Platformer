using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour {
    public float Speed;
    public GameObject BossBulletPrefabs;
    public int AmmountBulletClone;
    float radius;
    //Vector2 startPoint;
  

    private void Start()
    {
        radius = 5;
        //startPoint = transform.position;

        float rand = Random.Range(3, 5);
        StartCoroutine(CreateBulletClone(rand));

        Destroy(gameObject, rand + 0.1f);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    //IEnumerator CallMethod()
    //{
    //    yield return new WaitForSeconds(2.9f);
    //    CreateBulletClone();
    //}

    IEnumerator CreateBulletClone(float time)
    {
        yield return new WaitForSeconds(time);

        float angleStep = 360 / AmmountBulletClone;
        float angle = 0f;
        
        for (int i = 0; i <= AmmountBulletClone; i++)
        {
            float BulletDirXPos = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float BulletDirYPos = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 BulletVector = new Vector2(BulletDirXPos, BulletDirYPos);
            Vector2 MoveDir = (BulletVector - transform.position).normalized * Speed;

            var Bullet = Instantiate(BossBulletPrefabs, transform.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveDir.x, MoveDir.y);

            angle += angleStep;
        }
        Debug.Log("tes");
    }
}
