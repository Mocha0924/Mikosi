using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminagaugeController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    public void ChangeGauge()
    {
        transform.localPosition =new Vector3(transform.localPosition.x, slider.value*-105,0);
    }
}
