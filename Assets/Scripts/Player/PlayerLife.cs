using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Slider sliderHealthBar;
    public void Start()
    {
        currentHealth = maxHealth;
        sliderHealthBar.value = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        sliderHealthBar.value = currentHealth;
        if (currentHealth <= 2)
        {
            GameManager.instance.playerPossess.BecomeGhost();
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
