using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGPlay : MonoBehaviour
{
    public AudioSource soundSource;
    [SerializeField] private float minVolume = 1f;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float minPitch = 1f;
    [SerializeField] private float maxPitch = 1f;

    public void DMG()
    {
        soundSource.volume = Random.Range(minVolume, maxVolume);
        soundSource.pitch = Random.Range(minPitch, maxPitch);
        soundSource.Play();
    }
}