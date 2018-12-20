using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {
    public GameObject Bullet;
    public Transform BulletStart;

    public void Fire()
    {
        //Instantiate(Bullet, BulletStart.position, Quaternion.identity);
        GetComponent<Animator>().SetTrigger("Attack");
        Debug.Log("aaaa");
    }
}
