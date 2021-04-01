using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTester : MonoBehaviour
{
    public AudioClip soundToPlay;
    AudioSource audioSourceToUse;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceToUse = GetComponent<AudioSource>();
        InvokeRepeating("FireSound", 1.0f, 3.0f);
    }

    void FireSound()
    {
        audioSourceToUse.PlayOneShot(soundToPlay);
    }
}
