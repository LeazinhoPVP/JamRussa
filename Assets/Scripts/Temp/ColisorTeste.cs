using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorTeste : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FireSpawn fireSpawn = collision.gameObject.GetComponent<FireSpawn>();

            if (fireSpawn != null)
            {
                fireSpawn.SpawnObjectRandomly();
            }
        }
    }
}
