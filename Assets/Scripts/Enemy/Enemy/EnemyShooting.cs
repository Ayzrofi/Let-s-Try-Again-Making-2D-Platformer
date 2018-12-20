using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    
   
    public bool PlayerInRange;
    [Header("Bullet Prefabs")]
    public GameObject EnemyBulletPrefabs;
    [Header("bullet launcher")]
    public Transform BulletLauncher;
    [Header("Shoot Delay Speed")]
    public float ShootDelay;
    private float CurrentShootTimer;
    //[Header("Bullet Move Speed")]
    //public float BulletSpeed;
    [SerializeField]
    EnemyController enemyController;
    [SerializeField]
    Animator animatorController;

    private void Start()
    {
        if(enemyController == null)
            enemyController = GetComponent<EnemyController>();

        if (animatorController == null)
            animatorController = GetComponent<Animator>();
    }
    private void Update()
    {
        animatorController.SetBool("Attacking", PlayerInRange);
        ////CurrentShootTimer -= Time.deltaTime;
        //if (PlayerInRange /*&& Time.time > CurrentShootTimer*/)
        //{
        //    //Debug.Log(CurrentShootTimer);

        //    //CurrentShootTimer = Time.time + ShootDelay;
        //    //animatorController.SetBool("Attacking", true);
        //}
    }

    public void Shoot()
    {
        CreateBullet(EnemyBulletPrefabs, BulletLauncher, enemyController.FacingRight);
        //if (CurrentShootTimer < 0)
        //{
        //    CreateBullet(EnemyBulletPrefabs, BulletLauncher, enemyController.FacingRight);
        //    CurrentShootTimer = ShootDelay;
        //}
        //else
        //{
        //    CurrentShootTimer -= Time.deltaTime;
        //}
    }

    void CreateBullet(GameObject Prefabs,Transform Launcher, bool facingRight)
    {
        GameObject NewBullet = Instantiate(Prefabs, Launcher.position, Quaternion.identity) as GameObject;
        EnemyBulletController EnemyBulletController = NewBullet.GetComponent<EnemyBulletController>();
        //EnemyBulletController.Speed = (facingRight) ? EnemyBulletController.Speed : -EnemyBulletController.Speed;
        Vector3 LocalScale = NewBullet.transform.localScale;
        if (facingRight)
        {
            EnemyBulletController.Speed = EnemyBulletController.Speed;
            LocalScale.x *= -1;
            NewBullet.transform.localScale = LocalScale;
        }
        else
        {
            EnemyBulletController.Speed = -EnemyBulletController.Speed;
            LocalScale.x *= 1;
            NewBullet.transform.localScale = LocalScale;
        }
    }

   
}
