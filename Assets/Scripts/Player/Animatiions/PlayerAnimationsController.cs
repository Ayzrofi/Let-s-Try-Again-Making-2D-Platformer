using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour {
    public Animator animatorController;
    public InputAndroid PlayerMovement;
    public PlayerJump pJump;
    //public PlayerHealth pHealth;

    private void Awake()
    {
        if (PlayerMovement == null)
            PlayerMovement = GetComponent<InputAndroid>();

        if (pJump == null)
            pJump = GetComponent<PlayerJump>();

        //if (pHealth == null)
        //    pHealth = GetComponent<PlayerHealth>();

        if (animatorController == null)
            animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        animatorController.SetFloat("Jump", PlayerMovement.Rb.velocity.y);

    }

}
