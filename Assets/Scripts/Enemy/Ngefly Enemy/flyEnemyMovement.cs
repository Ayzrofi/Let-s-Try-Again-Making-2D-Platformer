using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class flyEnemyMovement : MonoBehaviour {

    public float NgeflySpeed;
    private Transform target;
    public LayerMask WhoIsPlayer;
    [Header("jarak sensor Player (Harus lebih dari 7)")]
    public float SensorDistance;
    private float AttackDistance;

    [HideInInspector]
    public bool PlayerInRange;
    [HideInInspector]
    public bool IsAttacking;

    Quaternion rotations = new Quaternion();
    FlyEnemyPatroll flyEnemyPatroll;

    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        flyEnemyPatroll = GetComponent<FlyEnemyPatroll>();
        //AttackDistance = Random.Range(4f, SensorDistance);
        //Debug.Log(AttackDistance);
    }

	void Update () {

        //PlayerInRange = Vector2.Distance(transform.position, target.position)  < AttackDistance;
        PlayerInRange = Physics2D.OverlapCircle(transform.position, SensorDistance, WhoIsPlayer);

        if (PlayerInRange)
        {
            IsAttacking = true;
            //IsAttacking = Vector2.Distance(transform.position, target.position) < AttackDistance;

            //if (!IsAttacking)
            //{
                transform.position = Vector3.MoveTowards(transform.position, target.position, NgeflySpeed * Time.deltaTime);
            //}
            Vector3 LookAngel = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(LookAngel.y, LookAngel.x) * Mathf.Rad2Deg;

            //rotations.eulerAngles = new Vector3(0, 0, angle );
            rotations.eulerAngles = (flyEnemyPatroll.FacingRight) ? new Vector3(0, 0, angle) : new Vector3(0, 0, angle - 180);

            transform.rotation = rotations;
        }else
        {
            IsAttacking = false;
        }
}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SensorDistance);
    }
}
