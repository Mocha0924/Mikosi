using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    Rigidbody my_Rigidbody;
    Transform my_Transform;
    Vector3 force;
    Vector3 pos;
    string Horizon_move;
    int Horizontal_controll;
    public float my_Thrust = 20f;
    public float my_Thrust_Max = 20f;
    public float my_forward_speed = 1f;
    public float jumpVector = 100f;
    public float gravity = 20f;
    [SerializeField] float slide_power = 2f;
    float Input_Horizontal;
    float old_Horizontal;

    // Start is called before the first frame update
    void Start()
    {
        my_Rigidbody = GetComponent<Rigidbody>();
        my_Transform = GetComponent<Transform>();

        pos = transform.position;

    }





    // Update is called once per frame
    void Update()
    {
        Input_Horizontal = Input.GetAxis("Horizontal");

        //my_Rigidbody.velocity = new Vector3(0, -gravity, my_forward_speed);


        if (Input_Horizontal - old_Horizontal > 0) { Horizontal_controll = 1; }
        else if (Input_Horizontal - old_Horizontal < 0) { Horizontal_controll = -1; }
        else if ((Input_Horizontal < 1 && Input_Horizontal > -1)) { Horizontal_controll = 0; }

        //if (-0.9f > Input_Horizontal && Input_Horizontal > -0.8f) { Input_Horizontal = 0; }
        //else { Input_Horizontal = -1; }

        Horizon_move = Horizontal_Contlroll(old_Horizontal, Input_Horizontal);

        if (Horizon_move == "leftmove")
        {



            if (my_Rigidbody.velocity.x > -my_Thrust_Max)
            {
                force = new Vector3(-my_Thrust, 0, 0);
            }
            else
            {
                force = new Vector3(0, 0, 0);

            }
        }
        else if (Horizon_move == "rightmove")
        {

            // if (0.9f > Input_Horizontal && Input_Horizontal > 0.8f) { Input_Horizontal = 0; }
            // else { Input_Horizontal = 1; }

            if (my_Rigidbody.velocity.x < my_Thrust_Max)
            {
                force = new Vector3(my_Thrust, 0, 0);
            }
            else
            {
                force = new Vector3(0, 0, 0);
            }
        }
        else
        {

            if (my_Rigidbody.velocity.x < 3 && my_Rigidbody.velocity.x > -3)
            {

                float now_velocity_y = my_Rigidbody.velocity.y;
                float now_velocity_z = my_Rigidbody.velocity.z;

                my_Rigidbody.velocity = new Vector3(0, now_velocity_y, now_velocity_z);



            }
            else
            {
                force = new Vector3(my_Rigidbody.velocity.x * -slide_power, 0, 0);
            }

        }


        force.y = -gravity;

        if (Input.GetKeyUp(KeyCode.Space) && transform.position.y <= 2)
        {
            float now_velocity_x = my_Rigidbody.velocity.x;
            float now_velocity_z = my_Rigidbody.velocity.z;
            my_Rigidbody.velocity = new Vector3(now_velocity_x, jumpVector, now_velocity_z);

        }

        force *= Time.deltaTime;
        my_Rigidbody.AddForce(force, ForceMode.Acceleration);

        Debug.Log(Horizon_move);
        old_Horizontal = Input_Horizontal;


    }



    private void FixedUpdate()
    {

        my_Transform.position += new Vector3(0, 0, my_forward_speed);


    }

    string Horizontal_Contlroll(float old, float input)
    {

        string Horizon_move = "0";

        if (old == 0)
        {
            if (input == 0) { Horizon_move = "dontmove"; }
            else if (input < 0) { Horizon_move = "leftmove"; }
            else if (input > 0) { Horizon_move = "rightmove"; }

        }
        else if (old < 0)
        {
            if(input == 0) { Horizon_move = "s"; }
            Horizon_move = "leftmove";
        }
        else if (old > 0)
        {
            Horizon_move = "rightmove";
        }

        return Horizon_move;


    }

}

