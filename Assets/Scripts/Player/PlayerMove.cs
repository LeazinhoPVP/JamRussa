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
        Aim();
        Move();

        float handDis = Mathf.Abs(Vector3.Distance(hand.transform.position, handPos.position));

        if (handDis >= 0.1f)
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, handPos.position, handDis * 5 * Time.deltaTime);

        if (GameManager.instance.playerIsGhost)
        {
            hand.SetActive(true);
        }
        else
        {
            hand.SetActive(false);
        }

    }
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        rb.velocity = moveDirection * moveSpeed;
        
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;
            var handDir = position - hand.transform.position;
            direction.y = 0;
            handDir.y = 0;

            //float pitch = Mathf.Atan2(direction.y, direction.magnitude) * Mathf.Rad2Deg;

            float handPitch = Mathf.Atan2(handDir.y, handDir.magnitude) * Mathf.Rad2Deg;

            head.transform.localRotation = Quaternion.Euler(-handPitch, 0, 0);
            head.transform.forward = handDir;
            hand.transform.rotation = Quaternion.LookRotation(handDir, Vector3.up);
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
