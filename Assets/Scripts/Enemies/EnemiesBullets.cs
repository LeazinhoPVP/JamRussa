using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesBullets : MonoBehaviour
{
    public float enemiesbulletVelocity;
    public int enemiesdamage;
    public float maxRange;
    public Collider bullet;
    private float range = 0.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * enemiesbulletVelocity * Time.deltaTime);
        range += enemiesbulletVelocity * Time.deltaTime;

        if (range >= maxRange)
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
                playerScript.TakeDamage();
            }
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        enemiesbulletVelocity = 0;
        bullet.enabled = false;
        Destroy(gameObject, 1f);
    }
}
