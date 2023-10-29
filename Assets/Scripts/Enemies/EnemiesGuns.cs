using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGuns : MonoBehaviour
{
    public Enemies enemy;
    public int enemyType;
    public GameObject bulletPrefab;
    public GameObject cane;
    public GameObject slugCaneA, slugCaneB, slugCaneC;
    public GameObject skullCaneA, skullCaneB, skullCaneC, skullCaneD;
    public float atackRate;

    private void Start()
    {
        StartCoroutine(DoAttack());
    }

    private IEnumerator DoAttack()
    {
        while (enemy.currentHealth > 0)
        {
            if(enemyType != 0)
            {
            enemy.animator.SetTrigger("Attack");        
            }
            else
            {
                Fire();
            }
            yield return new WaitForSeconds(atackRate);
        }
    }
    private IEnumerator Dash()
    {
        enemy.speed = 10;
        enemy.retreatDistance = 0;
        yield return new WaitForSeconds(1);
        enemy.retreatDistance = 5;
        enemy.speed = 5;
    }
    public void Fire()
    {
            switch (enemyType)
            {
                case 0:
                    //Ghost
                    AudioManager.audioManager.PlayerFire();
                    StartCoroutine(Dash());
                    break;
                case 1:
                    //Mosca
                    AudioManager.audioManager.MoscaFire();
                    FireBullet(cane.transform);
                    break;
                case 2:
                    //Caveira
                    AudioManager.audioManager.CaveiraFire();
                    FireBullet(skullCaneA.transform);
                    FireBullet(skullCaneB.transform);
                    FireBullet(skullCaneC.transform);
                    FireBullet(skullCaneD.transform);
                    break;
                case 3:
                    //Verme
                    AudioManager.audioManager.VermeFire();
                    FireBullet(slugCaneA.transform);
                    FireBullet(slugCaneB.transform);
                    FireBullet(slugCaneC.transform);
                    break;
                case 4:
                    //Demonio
                    AudioManager.audioManager.DemonioFire();
                    FireBullet(cane.transform);
                    break;
            }
    }
    private void FireBullet(Transform firePoint)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
