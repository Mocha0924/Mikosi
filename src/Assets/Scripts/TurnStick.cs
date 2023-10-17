using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStick : MonoBehaviour
{
    float Input_Horizontal = 0f;
    float Input_Vertical = 0f;
    bool stick_right = true; bool stick_left = false; bool stick_up = false; bool stick_down = false;
    public bool in_corner = false;
    public int turn_times = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (in_corner)
        {

            turnStick(tag == "R");
            
        }


       // Debug.Log(turn_times);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("trigger");
            in_corner = true;
            turn_times = 0;
        }
       
    }

    void turnStick(bool RorL)
    {
        
        
        

        Input_Horizontal = Input.GetAxis("Horizontal");
        Input_Vertical = Input.GetAxis("Vertical");

        if (RorL)
        {
            Right_corner();
        }
        else
        {
            Left_corner();
        }
    }

    void Right_corner()
    {
        

        if (Input_Horizontal > 0 && stick_right)
        {
            stick_right = false;
            stick_down = true;
        }
        else if (Input_Vertical < 0 && stick_down)
        {
            stick_down = false;
            stick_left = true;
        }
        else if (Input_Horizontal < 0 && stick_left)
        {
            stick_left = false;
            stick_up = true;
        }
        else if (Input_Vertical > 0 && stick_up)
        {
            stick_up = false;
            stick_right = true;
            turn_times += 1;

        }
    }

    void Left_corner()
    {
        
        if (Input_Horizontal < 0 && stick_left)
        {
            stick_left = false;
            stick_down = true;
        }
        else if (Input_Vertical < 0 && stick_down)
        {
            stick_down = false;
            stick_right = true;
        }
        else if (Input_Horizontal > 0 && stick_right)
        {
            stick_right = false;
            stick_up = true;
        }
        else if (Input_Vertical > 0 && stick_up)
        {
            stick_up = false;
            stick_left = true;

            
            turn_times += 1;

        }
    }


}
