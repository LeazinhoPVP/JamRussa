using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform[] spawnPoints;

    private void Start()
    {
        SpawnObjectRandomly();
    }

    public void SpawnObjectRandomly()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex].position;
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
