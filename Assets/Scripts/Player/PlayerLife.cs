using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    //public float maxHealth;
    //public float currentHealth;
    //public Slider sliderHealthBar;
    public Text debugTxt;

    public GameObject hand;

    public GameObject SFXDeath;

    public void Start()
    {
    }
    public void TakeDamage()
    {
        if (GameManager.instance.playerIsGhost)
        {
            AudioManager.audioManager.PlayerKill();
            Instantiate(SFXDeath, transform.position, Quaternion.identity);
            GameManager.instance.playerIsAlive = false;
            Invoke("PlayerDead", 3f);
            gameObject.SetActive(false);
            hand.SetActive(false);
        }
        else
        {
            GameManager.instance.playerPossess.BecomeGhost();
            AudioManager.audioManager.PlayerLoseBody();
        }
    }

    void PlayerDead()
    {
        SceneManager.LoadScene("Defeat");
    }
}
