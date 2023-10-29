using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float detectionRange;
    public float retreatDistance;
    public int maxHealth = 50;
    public int currentHealth;
    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                Vector3 directionToPlayer = player.position - transform.position;
                directionToPlayer.y = 0;
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                if (distanceToPlayer > retreatDistance)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(-Vector3.forward * speed * Time.deltaTime);
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
