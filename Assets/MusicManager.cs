using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    
    [SerializeField] private AudioClip startMusic;
    [SerializeField] private AudioClip runningMusic;
    
    private AudioSource _audioSource;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        _audioSource.clip = startMusic;
        _audioSource.Play();
    }
    
    public void StopMusic()
    {
        _audioSource.Stop();
    }
    
    public void PlayRunningMusic()
    {
        _audioSource.clip = runningMusic;
        _audioSource.Play();
    }
}
