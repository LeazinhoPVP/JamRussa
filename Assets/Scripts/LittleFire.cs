using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFire : MonoBehaviour
{
    public GameObject dungeon;
    public Transform dungeonLocation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnDungeon();
        }
    }

    private void SpawnDungeon()
    {
        Vector3 spawnPosition = dungeonLocation.position - new Vector3(0f, 1f, 0f);
        Instantiate(dungeon, spawnPosition, dungeonLocation.rotation);
        Destroy(gameObject);
    }
}
