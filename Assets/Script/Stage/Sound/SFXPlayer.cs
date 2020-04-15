using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWalkButler() {
        audioSource.PlayOneShot(SoundManager.GetAudioClip(Sound.ButlerWalking));
        //SoundManager.PlaySound(Sound.ButlerWalking);
    }

    public void PlayWalkMutant()
    {
        audioSource.PlayOneShot(SoundManager.GetAudioClip(Sound.MutantWalking));
    }

    public void PlayWalkBossMutant()
    {
        audioSource.PlayOneShot(SoundManager.GetAudioClip(Sound.BossMutantWalking));
    }

    public void PlayScreamMutant()
    {
        audioSource.PlayOneShot(SoundManager.GetAudioClip(Sound.MutantScreaming));
    }

    public void PlayBreathingMutant()
    {
        audioSource.PlayOneShot(SoundManager.GetAudioClip(Sound.MutantBreathing));
    }

    public void PlayDoorOpen()
    {
        audioSource.PlayOneShot(SoundManager.GetAudioClip(Sound.DoorOpen));
    }

    public void PlayDoorClose()
    {
        audioSource.PlayOneShot(SoundManager.GetAudioClip(Sound.DoorClose));
    }
}
