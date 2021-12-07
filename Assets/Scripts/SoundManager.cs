using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip playerJumpSound;
    [SerializeField] private AudioClip playerHeadBonkSound;
    [SerializeField] private AudioClip playerCollectCoinSound;
    [SerializeField] private AudioClip playerDeathSound;
    [SerializeField] private AudioClip playerDeathTune;
    [SerializeField] private AudioClip checkpointSound;
    [SerializeField] private AudioClip buttonClickSound;
    
    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        _audioSource.PlayOneShot(playerJumpSound);
    }
    
    public void PlayHeadBonkSound()
    {
        _audioSource.PlayOneShot(playerHeadBonkSound);
    }

    public void PlayCollectCoin()
    {
        _audioSource.PlayOneShot(playerCollectCoinSound);
    }
    
    public void PlayPlayerDeath()
    {
        _audioSource.PlayOneShot(playerDeathSound);
    }

    public void PlayPlayerDeathTune()
    {
        _audioSource.PlayOneShot(playerDeathTune);
    }
    
    public void PlayCheckpointSound()
    {
        _audioSource.PlayOneShot(checkpointSound);
    }
    
    public void PlayButtonClickSound()
    {
        _audioSource.PlayOneShot(buttonClickSound);
    }
}
