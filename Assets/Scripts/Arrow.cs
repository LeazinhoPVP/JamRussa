using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if (target != null)
        {
            gameObject.SetActive(true);
            transform.LookAt(target);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
