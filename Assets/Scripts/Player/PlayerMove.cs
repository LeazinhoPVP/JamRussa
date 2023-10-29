using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    private Camera mainCamera;
    public GameObject head;
    public float moveSpeed;
    public float dashSpeed; 
    public float dashDuration;
    public float dashCooldown;

    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && Time.time > dashCooldownTimer)
        {
            StartDash();
        }

        if (isDashing)
        {
            Dash();
        }
    }
    private void FixedUpdate()
    {
        Aim();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (!isDashing)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
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

    private void StartDash()
    {
        isDashing = true;
        dashTimer = 0f;
        dashCooldownTimer = Time.time + dashCooldown;
    }

    private void Dash()
    {
        dashTimer += Time.deltaTime;

        if (dashTimer >= dashDuration)
        {
            isDashing = false;
        }
        else
        {
            Vector3 moveDirection = transform.forward;
            float dashLerpFactor = Mathf.Clamp01(dashTimer / dashDuration);
            float currentSpeed = Mathf.Lerp(dashSpeed, moveSpeed, dashLerpFactor);
            transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);
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
