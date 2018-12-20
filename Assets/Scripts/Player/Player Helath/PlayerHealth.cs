using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(InputAndroid))]
public class PlayerHealth : MonoBehaviour {
    public int PlayerMaxHealth;
    public float maxVelocityY;
    [Header("Health Image For Player")]
    [SerializeField]
    GameObject[] HealthImage;
    public int PlayerCurrentHeath;
    [Header("Other Component")]
    public InputAndroid PlayerControll;
    private void Awake()
    {
        //Destroy(gameObject,4);
        PlayerCurrentHeath = PlayerMaxHealth = HealthImage.Length;

        if (PlayerControll == null)
            PlayerControll = GetComponent<InputAndroid>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy Bullet")
        {
            PlayerTakeDamage(1);
            PlayerControll.curKnockBackCounter = PlayerControll.knockBackCounter;
            if (other.transform.position.x > transform.position.x)
                PlayerControll.enemyInRightDirection = true;
            else
                PlayerControll.enemyInRightDirection = false;

        }
    }
    private void Update()
    {
        
        if (PlayerControll.Rb.velocity.y <= -maxVelocityY)
        {
            Debug.Log(PlayerControll.Rb.velocity.y);
            PlayerDeath();
        }
    }
    public void PlayerTakeDamage(int Damage)
    {
       
        if (PlayerCurrentHeath > 0)
        {
            PlayerCurrentHeath -= Damage;
            HealthImage[PlayerCurrentHeath].SetActive(false);
        } 

        if (PlayerCurrentHeath <= 0)
        {
            Debug.Log("You die");
            PlayerDeath();
        }
    }

    public void HealthPickUp(int HealtToAdd, GameObject HealthPickUpGameObject)
    {
        if (PlayerCurrentHeath < PlayerMaxHealth)
        {
            PlayerCurrentHeath += HealtToAdd;
            HealthImage[PlayerCurrentHeath - 1].SetActive(true);
            Destroy(HealthPickUpGameObject);
        }
    }
    public void PlayerDeath()
    {
        GetComponent<InputAndroid>().enabled = false;
        GetComponent<Animator>().SetTrigger("Die");
        Physics2D.IgnoreLayerCollision(13, 12, true);
        Physics2D.IgnoreLayerCollision(13, 11, true);
        //Physics2D.IgnoreLayerCollision(13, 10, true);
        //Destroy(gameObject);
        //SceneManager.LoadScene(Application.loadedLevel);
        Invoke("RestartGame", 2);
    }
    public void RestartGame()
    {
        Physics2D.IgnoreLayerCollision(13, 12, false);
        Physics2D.IgnoreLayerCollision(13, 11, false);
        //Physics2D.IgnoreLayerCollision(13, 10, false);
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
