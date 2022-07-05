using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudioCountrol : MonoBehaviour
{
    public AudioSource ZombieAudioSource;
    public AudioClip[] ZombieIdelSound;
    public AudioClip[] ZombieFootStepSound;
    public AudioClip AggresiveClip;
    void Start()
    {
        ZombieAudioSource.GetComponent<AudioSource>();
    }

    public void ActiveZombaiBreath()
    {
        ZombieAudioSource.volume = Random.Range(0f, 1f);
        int n=Random.Range(0,ZombieIdelSound.Length);
        ZombieAudioSource.clip= ZombieIdelSound[n];
        ZombieAudioSource.PlayOneShot(ZombieAudioSource.clip);
    }
    public void LeftFootSound()
    {
        //ZombieAudioSource.volume = Random.Range(0f, 1f);
        int n = Random.Range(0, ZombieFootStepSound.Length);
        ZombieAudioSource.clip = ZombieFootStepSound[n];
        ZombieAudioSource.PlayOneShot(ZombieAudioSource.clip);
    }
    public void RightFootSound()
    {
        //ZombieAudioSource.volume = Random.Range(0f, 1f);
        int n = Random.Range(0, ZombieFootStepSound.Length);
        ZombieAudioSource.clip = ZombieFootStepSound[n];
        ZombieAudioSource.PlayOneShot(ZombieAudioSource.clip);
    }
    public void AgressiveSound()
    {
        ZombieAudioSource.volume = 1;
        ZombieAudioSource.clip = AggresiveClip;
        ZombieAudioSource.PlayOneShot(ZombieAudioSource.clip);
    }
}
