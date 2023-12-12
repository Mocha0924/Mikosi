using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ScreenTransitions : MonoBehaviour
{


    [SerializeField] private Sprite[] ScreenSprits;
    [SerializeField] private GameObject[] BeforeObj;
    [SerializeField] private GameObject[] AfterObj;
    [SerializeField] bool decideButtonMode = false;
    int Sprites_Maxnum;
    int Sprites_Nownum;
    
    // Start is called before the first frame update
    void Start()
    {
        Sprites_Nownum = 0;
        Sprites_Maxnum = ScreenSprits.Length;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(decideButtonMode == true)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                Menutrantitons();
            }

            if (Input.GetKeyDown("space"))
            {
                Menutrantitons();
            }
        }
    }

    public void Menutrantitons()
    {

        foreach (var Before in BeforeObj)
        {
            Before.SetActive(false);
        }

        foreach(var After in AfterObj)
        {
            After.SetActive(true);
        }

    }

   
}
