using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour {

    public static PlayerInstance playerInstance;

    private void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
    }
}
