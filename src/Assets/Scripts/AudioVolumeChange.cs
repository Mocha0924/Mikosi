using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeChange : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    private void Start()
    {
        foreach(AudioSource source in audioSources)
        {
            if(source != null)
                source.volume = VolumeController.volume;
        }
    }
    public void VolumeChange()
    {
        foreach (AudioSource source in audioSources)
        {
            if (source != null)
                source.volume = VolumeController.volume;
        }
    }
}
