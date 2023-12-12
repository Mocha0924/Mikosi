using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    static public float volume = 1;
    [SerializeField] private Slider volumeSlider;
    private void Start()
    {
       volumeSlider.value = volume; 
    }
    public void VolumeChange()
    {
        volume = volumeSlider.value;
    }
}
