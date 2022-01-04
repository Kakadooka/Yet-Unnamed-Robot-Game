using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Handler : MonoBehaviour
{
    public AudioSource audioSource;
    //public var unavailableSocket, availableSocket, screwFalling;

    public void PlaySound(string audioName){
        var clip = Resources.Load<AudioClip>("sounds/"+audioName);
        audioSource.clip = clip;
        audioSource.Play();
    }
    
}
