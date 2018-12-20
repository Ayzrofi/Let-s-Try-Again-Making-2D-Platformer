using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {
    [SerializeField]
    private int HealthToAdd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            collision.GetComponent<PlayerHealth>().HealthPickUp(HealthToAdd,this.gameObject);
            Debug.Log("LOL");
        }
           
    }

}
