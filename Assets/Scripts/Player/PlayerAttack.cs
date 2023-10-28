using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform cane;
    public float firerate;

    private float lastFire;

    private void Start()
    {
        lastFire = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CanShoot())
        {
            Shoot();
        }
    }

    private bool CanShoot()
    {
        return Time.time - lastFire >= 1f / firerate;
    }

    private void Shoot()
    {
        if (balaPrefab != null && cane != null)
        {
            lastFire = Time.time;
            Instantiate(balaPrefab, cane.position, cane.rotation);
        }
    }
}
