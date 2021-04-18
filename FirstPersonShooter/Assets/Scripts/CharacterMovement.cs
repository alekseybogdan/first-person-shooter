using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float playerHeight = 2f;

    [SerializeField] Transform orientation;

    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float airMultiplier = 0.4f;
    float movementMultiplier = 10f;
    
    [Header("Sprinting")]
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float sprintSpeed = 5f;
    [SerializeField] float acceleration = 10f;

    [Header("Jumping")]
    public float jumpForce = 15f;

    [Header("Drag")]
    float groundDrag = 6f;
    float airDrag = 2f;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

    [Header("Ground Detection")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    float groundDistance = 0.4f;    

    private Rigidbody rb;

    RaycastHit slopeHit;

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
                return true;
            else
                return false;
        }
        return false;
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded();

        MyInput();
        ControlDrag();
        ControlSpeed();

        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = (orientation.forward * verticalMovement) + (orientation.right * horizontalMovement);
    }

    void ControlSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded())
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    void ControlDrag()
    {
        rb.drag = isGrounded() ? groundDrag : airDrag;
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (isGrounded() && !OnSlope())
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        else if(isGrounded() && OnSlope())
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        else
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
    }

    private bool isGrounded()
    {
        //Test that we are grounded by drawing an invisible line (raycast)
        //If this hits a solid object e.g. floor then we are grounded.
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
