using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float launchForce = 10f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = launchForce * transform.forward;
    }
}