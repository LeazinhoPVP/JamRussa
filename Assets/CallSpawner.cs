using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSpawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.dungeonSpawner.SpawnDungeon();
            Destroy(gameObject);
        }
    }
}
