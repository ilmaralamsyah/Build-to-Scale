using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip clickSFX;
    [SerializeField] private AudioClip doorLockSFX;
    [SerializeField] private AudioClip doorRevealSFX;
    [SerializeField] private AudioClip doorUnlockedSFX;
    [SerializeField] private AudioClip dropSFX;
    [SerializeField] private AudioClip pickSFX;
    [SerializeField] private AudioClip scaleSFX;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSFX()
    {
        audioSource.PlayOneShot(clickSFX, 1f);
    }

    public void PlayDoorLockSFX()
    {
        audioSource.PlayOneShot(doorLockSFX, 1f);
    }

    public void PlayDoorRevealSFX()
    {
        audioSource.PlayOneShot(doorRevealSFX, 1f);
    }

    public void PlayDoorUnlockedSFX()
    {
        audioSource.PlayOneShot(doorUnlockedSFX, 1f);
    }

    public void PlayDropSFX()
    {
        audioSource.PlayOneShot(dropSFX, 1f);
    }

    public void PlayPickSFX()
    {
        audioSource.PlayOneShot(pickSFX, 1f);
    }

    public void PlayScaleSFX()
    {
        audioSource.PlayOneShot(scaleSFX, 1f);
    }
}
