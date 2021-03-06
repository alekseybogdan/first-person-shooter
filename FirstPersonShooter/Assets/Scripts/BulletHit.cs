﻿using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
    public GameObject particle;
    public GameObject bloodFX;
    public int damage;

    //When we touch the collider we disable this object.
    void OnCollisionEnter(Collision other)
    {
        //Find the contact point on the object we collided with.
        ContactPoint contact = other.contacts[0];
        //Set the exact position and rotation we hit the collider at.
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;   
        var partcielToSpawn = other.transform.CompareTag("Enemy") ? bloodFX : particle;
        Instantiate(partcielToSpawn, pos, rot);
        gameObject.SetActive(false);
    }
}
