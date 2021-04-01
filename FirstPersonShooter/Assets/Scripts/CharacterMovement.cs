using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float walkSpeed = 2f;
    public float sprintSpeed = 4f;
    public float acceleration = 2f;
    public float jumpPower = 4f;
    public bool Grounded;
    private Rigidbody rb;
    private CapsuleCollider col;
    private float Horizontal;
    private WallRunning wr;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        wr = GetComponent<WallRunning>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = isGrounded();
        bool isWall = false;
        if (wr != null)
        {
            isWall = wr.isWall;
        }
        //Get the input value from the controllers
        float Vertical = Input.GetAxis("Vertical") * moveSpeed;
        if (!isWall)
        {
            Horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        }
        Vertical *= Time.deltaTime;
        Horizontal *= Time.deltaTime;
        //Translate our character via our inputs.
        //transform.Translate(Horizontal, 0, Vertical);
        Vector3 velocity = (transform.forward * Vertical) + (transform.right * Horizontal) + (transform.up * rb.velocity.y);
        rb.velocity = velocity;

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded())
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }

        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            //Add upward force to the rigid body when we press jump.
            rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        }
    }

    private bool isGrounded()
    {
        //Test that we are grounded by drawing an invisible line (raycast)
        //If this hits a solid object e.g. floor then we are grounded.
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }
}
