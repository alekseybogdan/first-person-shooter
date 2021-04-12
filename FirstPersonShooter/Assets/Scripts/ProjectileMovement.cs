using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float launchForce = 10f;
    Rigidbody rb;
    Ray ray;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = launchForce * ray.direction;
    }
}