using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    private Camera mainCamera;
    public GameObject head;
    public float moveSpeed = 5.0f;
    public float sensitivity, minVerticalAngle, maxVerticalAngle;


    void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        Move();
    }
    void FixedUpdate()
    {
        Aim();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(verticalInput, 0, -horizontalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;
            direction.y = 0;

            float pitch = Mathf.Atan2(direction.y, direction.magnitude) * Mathf.Rad2Deg;
            head.transform.localRotation = Quaternion.Euler(-pitch, 0, 0);
            transform.forward = direction;
        }
    }


    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, 100, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }



}