using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Slider sliderHealthBar;
    public Text debugTxt;
    public void Start()
    {
        currentHealth = maxHealth;
        sliderHealthBar.value = maxHealth;
        debugTxt.text = currentHealth.ToString();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        sliderHealthBar.value = currentHealth;
        debugTxt.text = currentHealth.ToString();
        if (currentHealth <= 2)
        {
            GameManager.instance.playerPossess.BecomeGhost();
            AudioManager.audioManager.PlayerLoseBody();
        }
        if (currentHealth <= 0)
        {
            AudioManager.audioManager.PlayerKill();
            Destroy(gameObject);
        }
    }
}
