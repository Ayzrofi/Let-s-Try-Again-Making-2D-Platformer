using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunShooting : MonoBehaviour {
    [SerializeField]
    EnemyMachineGun machineGun;
    // Delay Waktu Untuk Menembak 
    public float ShootDelay;
    private float CurShootDelay;
    // getting prefabs bulletflyenemy
    public GameObject BulletFlyEnemy;
    // Posisi Instance peluru
    public Transform BulletShootPoint;
 
    private void Awake()
    {
        // ngecek Aja 
        if (machineGun == null)
            machineGun = GetComponent<EnemyMachineGun>();
    }
    private void Update()
    {
        // ngecek apabila si Player dalam Jarak Tembak
        if (machineGun.PlayerInRange)
        {
            ShootingBulletProjectile(BulletFlyEnemy, BulletShootPoint);
        }
    }
    // function for Instance Bullet Prefabs
    public void ShootingBulletProjectile(GameObject Prefabs, Transform ShootPoint)
    {
        if (CurShootDelay <= 0)
        {
            Instantiate(Prefabs, ShootPoint.position, ShootPoint.transform.rotation);
            CurShootDelay = ShootDelay;
        }
        else
        {
            CurShootDelay -= Time.deltaTime;
        }

    }
}
