using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset;
    public float smoothSpeed = 5.0f;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
