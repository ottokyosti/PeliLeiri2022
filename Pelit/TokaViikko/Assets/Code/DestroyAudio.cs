using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private float audioLength;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioLength = audioSource.clip.length;
        Destroy(this.gameObject, audioLength);
    }
}
