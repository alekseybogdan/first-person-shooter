using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(AudioSource))]
public class GunPickup : MonoBehaviour
{
    UseAttacks useAttacks;
    public Gun gun;
    public AudioClip soundToPlay;
    AudioSource audioSource;
    Collider boxCollider;
    Floater floater;
    VisualEffect pickupFX;

    bool isActive = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
        floater = GetComponentInChildren<Floater>();
        pickupFX = GetComponentInChildren<VisualEffect>();
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
            pickupFX.enabled = false;
            isActive = false;
        }
    }
}
