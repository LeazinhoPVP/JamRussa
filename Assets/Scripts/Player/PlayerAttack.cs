using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform cane;
    public float firerate;
    public int type;
    public GameObject slugCaneA, slugCaneB, slugCaneC;
    public GameObject skullCaneA, skullCaneB, skullCaneC, skullCaneD, skullCaneE;
    public Animator animator;
    private bool resumeFire = true;

    private float lastFire;

    private void Start()
    {
        lastFire = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && CanShoot() && resumeFire)
        {
            animator.SetTrigger("Attack");
            resumeFire = false;
        }
    }
    public void EndedAnimation()
    {
        resumeFire = true;
    }
    private bool CanShoot()
    {
        return Time.time - lastFire >= firerate;
    }
    private void FireBullet(Transform firePoint)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        lastFire = Time.time;
    }
    public void Shoot()
    {
        switch (type)
        {
            case 0:
                //Ghost
                AudioManager.audioManager.PlayerFire();
                FireBullet(cane.transform);
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
                FireBullet(skullCaneE.transform);
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
}
