using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    //public Slider sliderHealthBar;
    public void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
