using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFire : MonoBehaviour
{
    public GameObject[] dungeon = new GameObject[7];
    public int[] enemyQuantity = new int[6]; 
    int enemiesKilled = 0;
    public Transform dungeonLocation;
    public GameObject actualDungeonObj;
    public FireSpawn fireSpawn;

    private void Start()
    {
        //dungeonLocation = GameManager.instance.player.transform;
        GameManager.instance.dungeonSpawner = this;
        //fireSpawn.SpawnObjectRandomly();
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
    public void SpawnDungeon()
    {
        AudioManager.audioManager.InCombat = 1;
        Vector3 spawnPosition = dungeonLocation.position - new Vector3(0f, 0f, 0f);
        GameObject i = Instantiate(dungeon[GameManager.instance.actualDungeon], spawnPosition, dungeonLocation.rotation);
        actualDungeonObj = i;
    }
}
