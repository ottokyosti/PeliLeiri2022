using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDestroy : MonoBehaviour
{
    private void Start()
    {
        float timeToDie = GetComponent<AudioSource>().clip.length;
        Destroy(this.gameObject, timeToDie);
    }
}
