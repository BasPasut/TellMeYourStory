using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       audioSource = this.transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWalkButler() {
        //audioSource.PlayOneShot(Sound.Breathing);
    }

    public void PlayWalkMutant()
    {
        
    }

    public void PlayWalkBossMutant()
    {
        
    }

    public void PlayScreamMutant()
    {

    }

    public void PlayBreathingMutant()
    {

    }

    public void PlayDoorOpen()
    {

    }

    public void PlayDoorClose()
    {

    }
}
