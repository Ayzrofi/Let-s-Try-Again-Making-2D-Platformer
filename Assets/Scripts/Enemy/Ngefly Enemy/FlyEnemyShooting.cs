using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyShooting : MonoBehaviour {

    public float ShootDelay;
    private float CurShootDelay;
    public GameObject BulletFlyEnemy;
    public Transform BulletShootPoint;
    [SerializeField]
    flyEnemyMovement flyEnemyMovement;
    private void Awake()
    {
        if (flyEnemyMovement == null)
            flyEnemyMovement = GetComponent<flyEnemyMovement>();
    }
    private void Update()
    {
        if (flyEnemyMovement.IsAttacking)
        {
            ShootingBulletProjectile(BulletFlyEnemy, BulletShootPoint);
        }
    }

    public void ShootingBulletProjectile(GameObject Prefabs,Transform ShootPoint)
    {
        if(CurShootDelay <= 0)
        {
            Instantiate(Prefabs, ShootPoint.position, ShootPoint.transform.rotation);
            CurShootDelay = ShootDelay;
        }else
        {
            CurShootDelay -= Time.deltaTime;
        }
       
    }
}
