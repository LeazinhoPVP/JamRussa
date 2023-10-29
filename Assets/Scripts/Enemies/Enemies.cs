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
    float timer = 0;
    public Animator animator;
    private void Start()
    {
        player = GameManager.instance.player.transform;
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
        if(currentHealth <= 0)
        {
            if(maxHealth == 2)
            {
                Destroy(gameObject);
            }
            rotationSpeed = 0;
            animator.speed = 0;
            speed = 0;
            timer += Time.deltaTime;
            if(timer > 5)
            {
                GameManager.instance.dungeonSpawner.EnemyCounter();
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
