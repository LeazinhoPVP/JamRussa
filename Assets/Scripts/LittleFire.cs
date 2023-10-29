using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFire : MonoBehaviour
{
    public GameObject[] dungeon = new GameObject[7];
    public int[] enemyQuantity = new int[6]; 
    int enemiesKilled = 0;
    public Transform dungeonLocation;
    private GameObject actualDungeonObj;
    public FireSpawn fireSpawn;

    private void Start()
    {
        dungeonLocation = GameManager.instance.player.transform;
        GameManager.instance.dungeonSpawner = this;
        fireSpawn.SpawnObjectRandomly();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            SpawnDungeon();
        }
    }
    public void EnemyCounter()
    {
        enemiesKilled++;
        if (enemiesKilled == enemyQuantity[GameManager.instance.actualDungeon])
        {
            enemiesKilled = 0;
            GameManager.instance.actualDungeon++;
            Destroy(actualDungeonObj);
            fireSpawn.SpawnObjectRandomly();
        }
    }
    private void SpawnDungeon()
    {
        AudioManager.audioManager.InCombat = 1;
        Vector3 spawnPosition = dungeonLocation.position - new Vector3(0f, 0f, 0f);
        actualDungeonObj = Instantiate(dungeon[GameManager.instance.actualDungeon], spawnPosition, dungeonLocation.rotation);
        Destroy(gameObject);
    }
}
