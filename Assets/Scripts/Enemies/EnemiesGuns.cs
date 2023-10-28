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
                    Instantiate(bulletPrefab, cane.transform.position, cane.transform.rotation);
                }
                else
                {
                    Instantiate(bulletPrefab, shotgunCaneA.transform.position, shotgunCaneA.transform.rotation);
                    Instantiate(bulletPrefab, shotgunCaneB.transform.position, shotgunCaneB.transform.rotation);
                    Instantiate(bulletPrefab, shotgunCaneC.transform.position, shotgunCaneC.transform.rotation);
                }
            }
        }
    }
}
