using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioLevelChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private string volumeName;

    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public void SetSoundOnOffMusic()
    {
        if (toggle.isOn)
        {
            mixer.SetFloat(volumeName, -80f);
        }
        else
        {
            mixer.SetFloat(volumeName, 0);
        }
    }

    public void SetSoundOnOffSFX()
    {
        if (toggle.isOn)
        {
            mixer.SetFloat(volumeName, -80f);
        }
        else
        {
            mixer.SetFloat(volumeName, 0);
        }
    }
}
