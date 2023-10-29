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
        while (true)
        {
            yield return new WaitForSeconds(atackRate);
            enemy.animator.SetTrigger("Attack");
            
        }
    }
    public void Fire()
    {

        if (bulletPrefab != null)
        {
            switch (enemyType)
            {
                case 0:
                    //Ghost
                    FireBullet(cane.transform);
                    break;
                case 1:
                    //Mosca
                    FireBullet(cane.transform);
                    break;
                case 2:
                    //Caveira
                    FireBullet(skullCaneA.transform);
                    FireBullet(skullCaneB.transform);
                    FireBullet(skullCaneC.transform);
                    FireBullet(skullCaneD.transform);
                    break;
                case 3:
                    //Verme
                    FireBullet(slugCaneA.transform);
                    FireBullet(slugCaneB.transform);
                    FireBullet(slugCaneC.transform);
                    break;
                case 4:
                    //Demonio
                    FireBullet(cane.transform);
                    break;
            }
        }
    }
    private void FireBullet(Transform firePoint)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
