using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBullet : MonoBehaviour
{
    public float bulletVelocity;
    public int damage = 10;

    void Update()
    {
        transform.Translate(Vector3.forward * bulletVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemies enemyScript = other.gameObject.GetComponent<Enemies>();

            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
