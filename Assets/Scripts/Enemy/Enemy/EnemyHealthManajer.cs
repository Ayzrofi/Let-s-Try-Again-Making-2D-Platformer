using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManajer : MonoBehaviour {
    public int MaxHealth;
    [Header("Jumlah Health Image")]
    public GameObject[] HeartImage;
   
    private int CurrentHealth;
    [Header("Damage Yg akan di Terima Enemy")]
    public int DamageToRecieve;

    private void Awake()
    {
        CurrentHealth = MaxHealth = HeartImage.Length;
        // important for me lol
        foreach (GameObject hearth in HeartImage)
        {
            hearth.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag.Equals("Bullet"))
        {
            TakeDamage(DamageToRecieve);
        }
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        // important for me lol
        HeartImage[CurrentHealth].SetActive(false);
        if (CurrentHealth <= 0)
            Destroy(gameObject);
    }
}
