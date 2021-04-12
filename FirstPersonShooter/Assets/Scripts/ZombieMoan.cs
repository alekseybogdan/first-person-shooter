using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoan : MonoBehaviour
{
    public AudioClip[] audioClips;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("FireSound", 1f, 3f);
    }

    void FireSound()
    {
        if (audioSource.isActiveAndEnabled)
        {
            int index = Random.Range(0, audioClips.Length);
            AudioClip soundToPlay = audioClips[index];
            audioSource.PlayOneShot(soundToPlay);
        }
    }
}
