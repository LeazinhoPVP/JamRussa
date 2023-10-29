using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXTester : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public GameObject bullet;


    public ParticleSystem particle;


    public bool projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }



    void ProjectHit()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(projectile && collision.gameObject.CompareTag("Dummy"))
        {

        }
    }
}
