using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGuns : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject cane;
    public GameObject shotgunCaneA, shotgunCaneB, shotgunCaneC;
    public bool isShotgun = false;
    public float firerate;
    public int weaponDamage;
    private void Start()
    {
        cane.SetActive(!isShotgun);
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / firerate);

            if (bulletPrefab != null)
            {
                if (!isShotgun)
                {
                    FireBullet(cane.transform);
                }
                else
                {
                    FireBullet(shotgunCaneA.transform);
                    FireBullet(shotgunCaneB.transform);
                    FireBullet(shotgunCaneC.transform);
                }
            }
        }
    }

    private void FireBullet(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        EnemiesBullets bulletScript = bullet.GetComponent<EnemiesBullets>();

        if (bulletScript != null)
        {
            bulletScript.enemiesdamage = weaponDamage;
        }
    }


}
