using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
public class MixerTest : MonoBehaviour
{
    public AudioMixer mixerToUse;
    void Start()
    {
        mixerToUse.SetFloat("currentVolumeForFX", -10.0f);
    }
}