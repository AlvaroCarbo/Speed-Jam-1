using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip footstep;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip land;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void AtPoint(AudioClip clip, Vector3 vector3, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(clip, vector3, volume);
    }
    
    public void OneShot(AudioClip clip, float volume = 1f)
    {
        _audioSource.PlayOneShot(clip, volume);
    }
    
    // public void PlayFootstepAtPoint()
    // {
    //     AtPoint(footstep, transform.position);
    // }
    
    public void PlayFootstep()
    {
        OneShot(footstep);
    }
    
    public void PlayJump()
    {
        OneShot(jump);
    }
    
    public void PlayLand()
    {
        OneShot(land);
    }
}
