using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washoi_script : MonoBehaviour
{

    float Input_washoi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input_washoi = Input.GetAxis("Fire1");

        if(Input_washoi < 0)
        {
           // if()
            GameObject.Find("LoadDirector");
        }

        Debug.Log(Input_washoi);
    }
}
