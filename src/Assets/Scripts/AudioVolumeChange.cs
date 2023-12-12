using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeChange : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] Slider Slider;
    [SerializeField] GameObject cursor;
    [SerializeField] int volume_Variation = 10;
    float Slider_Maxnum = 1.0f;
    public float Slider_Nownum = 1.0f;
    float lsh;

    public enum ButtonType
    {
        Normal,
        Up,
        Down
    }
    public enum input_or
    {
        Vertical,
        Horizontal
    }

    public ButtonType buttonType = ButtonType.Normal;
    public input_or input = input_or.Vertical;


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

    public void Update()
    {
        

        if (input == input_or.Vertical)
        {
            lsh = Input.GetAxis("Vertical");
        }
        else
        {
            lsh = -1 * Input.GetAxis("Horizontal");
        }


        if ((lsh >= 0.8f) && buttonType == ButtonType.Normal)
        {
            if (Slider_Nownum > 0.01f)
            {
                Slider_Nownum -= 1.0f / (volume_Variation - 1) ;
                Slider.value = Slider_Nownum;
                buttonType = ButtonType.Up;
               // cursor.transform.localPosition = Buttons[Button_Nownum].transform.localPosition;
                
            }


        }
        if ((lsh <= -0.8f) && buttonType == ButtonType.Normal)
        {
            if (Slider_Nownum < Slider_Maxnum)
            {
                Slider_Nownum += 1.0f / (volume_Variation - 1);
                Slider.value = Slider_Nownum;
                buttonType = ButtonType.Down;
                //cursor.transform.localPosition = Buttons[Button_Nownum].transform.localPosition;
            }

        }
        if ((lsh == 0) && buttonType == ButtonType.Up)
            buttonType = ButtonType.Normal;
        if ((lsh == 0) && buttonType == ButtonType.Down)
            buttonType = ButtonType.Normal;
    }





}
