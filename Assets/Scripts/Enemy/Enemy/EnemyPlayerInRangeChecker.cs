using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerInRangeChecker : MonoBehaviour {
    public EnemyShooting eShot;
    private void Start()
    {
        if( eShot == null)
        eShot = transform.GetComponentInParent<EnemyShooting>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            eShot.PlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            eShot.PlayerInRange = false;
        }
        
    }
}
