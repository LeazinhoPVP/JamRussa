using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    public Camera mainCamera;
    public GameObject head;
    public GameObject hand;
    public Transform handPos;
    public float moveSpeed;
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;

    private bool isDashing = false;
    private float dashCooldownTimer = 0f;

    private Rigidbody rb;



    public bool ghost = true;

    void Start()
    {
        GameManager.instance.player = this;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    private void Update()
    {
        Move();

        float handDis = Mathf.Abs(Vector3.Distance(hand.transform.position, handPos.position));

        if (handDis >= 0.1f)
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, handPos.position, handDis * 4 * Time.deltaTime);
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
            rb.velocity = moveDirection * moveSpeed;
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
            head.transform.forward = direction;
            hand.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }

    private void StartDash()
    {
        isDashing = true;
        rb.velocity = Vector3.zero;
        dashCooldownTimer = Time.time + dashCooldown;
    }

    private void Dash()
    {
        Vector3 moveDirection = head.transform.forward;
        rb.velocity = moveDirection * dashSpeed;
        if (Time.time >= dashCooldownTimer)
        {
            isDashing = false;
            rb.velocity = Vector3.zero;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction * 100);
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
