using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}