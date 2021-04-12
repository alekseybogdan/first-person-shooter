using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunPickup : MonoBehaviour
{
    UseAttacks useAttacks;
    public Gun gun;
    public AudioClip soundToPlay;
    AudioSource audioSource;
    Collider boxCollider;
    Floater floater;

    bool isActive = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
        floater = GetComponent<Floater>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && isActive)
        {
            useAttacks = other.GetComponentInChildren<UseAttacks>();
            useAttacks.EquipGun(gun);
            audioSource.PlayOneShot(soundToPlay);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            boxCollider.enabled = false;
            floater.enabled = false;
            isActive = false;
        }
    }
}
