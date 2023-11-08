using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Finish"))
        {
            Application.Quit();
        }
    }
}
