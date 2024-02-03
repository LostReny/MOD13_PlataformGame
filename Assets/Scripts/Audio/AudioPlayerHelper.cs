using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerHelper : MonoBehaviour
{
    public AudioSource audioSource;


    public void PlayAudio() {

        if (!audioSource.isPlaying)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
}
