using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesBullets : MonoBehaviour
{
    public float enemiesbulletVelocity;
    public int enemiesdamage;
    public float maxRange;
    private float distanceTraveled = 0.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * enemiesbulletVelocity * Time.deltaTime);
        distanceTraveled += enemiesbulletVelocity * Time.deltaTime;

        if (distanceTraveled >= maxRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLife playerScript = other.gameObject.GetComponent<PlayerLife>();

            if (playerScript != null)
            {
                playerScript.TakeDamage(enemiesdamage);
            }

            Destroy(gameObject);
        }
    }
}
