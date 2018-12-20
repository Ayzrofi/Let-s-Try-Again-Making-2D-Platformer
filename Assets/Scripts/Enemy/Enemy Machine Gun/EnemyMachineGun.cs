using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMachineGun : MonoBehaviour {
    // si Player
    private Transform target;
    // layer mask si player
    public LayerMask WhoIsPlayer;
    [Header("jarak sensor Player (Harus lebih dari 7)")]
    public float SensorDistance;
    // jarak tertentu agar enemy nyerang si player
    private float AttackDistance;

    [HideInInspector]
    // ngecek player apakah dalam jangkauan Tembak
    public bool PlayerInRange;
    // cuma variabel rotasi kok :)
    Quaternion rotations = new Quaternion();
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // ngecek player apakah dalam jangkauan Tembak
        PlayerInRange = Physics2D.OverlapCircle(transform.position, SensorDistance, WhoIsPlayer);
        if (PlayerInRange)
        {
            // mengubah rotasi agar selalu mengarah ke Player
            Vector3 LookAngel = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(LookAngel.y, LookAngel.x) * Mathf.Rad2Deg;
            rotations.eulerAngles = new Vector3(0, 0, angle - 180);
            transform.rotation = rotations;
        }
    }
    // untuk membuat gizmoz terlihat di editor gan ;)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SensorDistance);
    }
}
