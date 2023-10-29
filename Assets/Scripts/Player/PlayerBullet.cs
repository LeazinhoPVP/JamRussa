using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBullet : MonoBehaviour
{
    public float bulletVelocity;
    public int damage = 10;
    public Collider bullet;

    public ParticleSystem HitEffect;

    void Update()
    {
        transform.Translate(Vector3.forward * bulletVelocity * Time.deltaTime);
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemies enemyScript = other.gameObject.GetComponent<Enemies>();

            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);
                AudioManager.audioManager.HitEnemy();
            }
            DestroyBullet();
        }
        if(other.gameObject.CompareTag("Wall") == true)
        {
            DestroyBullet();
            AudioManager.audioManager.HitMisc();
        }
    }

    private void DestroyBullet()
    {
        bulletVelocity = 0;
        bullet.enabled = false;
        HitEffect.Play();

        Destroy(gameObject, 1f);
    }
}
