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
    private void Start()
    {
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
        Enemies enemyTest = other.GetComponent<Enemies>();
        EnemiesGuns enemy = other.GetComponent<EnemiesGuns>();
        if (enemyTest.currentHealth <= 0)
        {
            Destroy(enemy.gameObject);
            playerBodies[playerBody].SetActive(false);
            playerBodies[enemy.enemyType].SetActive(true);
            playerBody = enemy.enemyType;
            playerMove.head = playerBodies[playerBody];
            canPosses = false;
        }
    }
    IEnumerator Possess()
    {
        possessing = true;
        yield return new WaitForSeconds(0.2f);
        possessing = false;
    }
}
