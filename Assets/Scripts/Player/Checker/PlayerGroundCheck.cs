﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour {

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Asu");
    }
}
