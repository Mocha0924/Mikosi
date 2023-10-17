using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    Rigidbody my_Rigidbody;
    Transform my_Transform;
    Vector3 force;
    Vector3 pos;
    public float my_Thrust = 20f;
    public float my_Thrust_Max = 20f;
    public float my_forward_speed = 1f;
    public float jumpVector = 100f;
    public float gravity = 20f;
    [SerializeField] float slide_power = 2f;
    float Input_Horizontal;

    public bool turn_complete_R = false;
    public bool turn_complete_L = false;
    [SerializeField] int Turn_speed = 1;
    float turn_times = 0f;


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

        if (Input_Horizontal < 0)
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

        if (Input_Horizontal > 0)
        {
            if (my_Rigidbody.velocity.x < my_Thrust_Max)
            {
                force = new Vector3(my_Thrust, 0, 0);
            }
            else
            {
                force = new Vector3(0, 0, 0);
            }



        }


       // Debug.Log(Input_Horizontal);

        //Debug.Log(my_Rigidbody.velocity);

        if (!Input.anyKey)
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


    }



    private void FixedUpdate()
    {

        if (turn_complete_R)
        {
            turn_times += Turn_speed;

            transform.rotation = Quaternion.Euler(0, turn_times, 0);

            if (turn_times % 90 == 0)
            {
                turn_complete_R = false;
            }
        }
        else if (turn_complete_L)
        {
            turn_times += Turn_speed;

            transform.rotation = Quaternion.Euler(0, -turn_times, 0);

            if (turn_times % 90 == 0)
            {
                turn_complete_L = false;
            }
        }
        else
            my_Transform.position += transform.forward * my_forward_speed;

        //my_Transform.position += new Vector3(0, 0, my_forward_speed);


    }

}
