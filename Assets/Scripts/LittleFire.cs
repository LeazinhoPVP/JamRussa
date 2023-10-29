using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFire : MonoBehaviour
{
    public GameObject dungeon;
    public Transform dungeonLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            SpawnDungeon();
        }
    }

    private void SpawnDungeon()
    {
        Vector3 spawnPosition = dungeonLocation.position - new Vector3(0f, 0f, 0f);
        Instantiate(dungeon, spawnPosition, dungeonLocation.rotation);
        Destroy(gameObject);
    }
}
