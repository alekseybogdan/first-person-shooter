using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    private int hitNumber;
    public GameObject ragdoll;

    private void OnEnable()
    {
        hitNumber = 0;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.transform.CompareTag("Bullet"))
        {
            //If the comparison is true, we increase the hit number.
            hitNumber++;
        }
        if (hitNumber == 3)
        {
            gameObject.SetActive(false);
            Instantiate(ragdoll, transform.position, transform.rotation);
        }
    }
}