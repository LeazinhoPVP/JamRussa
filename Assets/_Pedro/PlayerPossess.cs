using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossess : MonoBehaviour
{
    public bool possessing = false;
    public bool canPosses = true;
    public int playerBody = 0;
    [SerializeField] GameObject[] playerBodies = new GameObject[5];
    [SerializeField] PlayerMove playerMove;
    [SerializeField] PlayerLife life;
    EnemiesGuns enemy;
    Enemies enemyTest;
    private void Start()
    {
        GameManager.instance.playerPossess = this;
        playerMove.head = playerBodies[playerBody];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canPosses)
        {
            if (other.CompareTag("Enemy"))
            {
                startProcess(other);
            }
        }     
    }
    public void startProcess(Collider other)
    {
        enemyTest = other.GetComponent<Enemies>();
        enemy = other.GetComponent<EnemiesGuns>();
        if (enemyTest.currentHealth <= 0)
        {
            Destroy(enemy.gameObject);
            playerBodies[playerBody].SetActive(false);
            playerBodies[enemy.enemyType].SetActive(true);
            playerBody = enemy.enemyType;
            playerMove.head = playerBodies[playerBody];
            canPosses = false;
            life.maxHealth =  3;
            if(life.currentHealth < life.maxHealth)
            {
            life.currentHealth += 1;
            }
            GameManager.instance.dungeonSpawner.EnemyCounter();
        }
    }
    public void BecomeGhost()
    {
        playerBodies[playerBody].SetActive(false);
        playerBodies[0].SetActive(true);
        playerBody = 0;
        playerMove.head = playerBodies[0];
        canPosses = true;
        life.maxHealth = 2;
        if (life.currentHealth > life.maxHealth)
        {
            life.currentHealth += life.maxHealth;
        }
    }
    IEnumerator Possess()
    {
        possessing = true;
        yield return new WaitForSeconds(0.2f);
        possessing = false;
    }
}
