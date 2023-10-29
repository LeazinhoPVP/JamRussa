using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Transform selectedSpawnPoint = spawnPoints[randomSpawnIndex];
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomEnemyIndex];
            Instantiate(enemyPrefab, selectedSpawnPoint.position, Quaternion.identity);
        }
    }
}
