using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    Rigidbody my_Rigidbody;
    Transform my_Transform;
    Vector3 force;
    Vector3 pos ;
    public float my_Thrust = 20f;
    public float my_Thrust_Max = 20f;
    public float my_forward_speed = 1f;
    public float jumpVector = 100f;
    public float gravity = 20f;
    float Input_Horizontal;

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

        
       

        //Debug.Log(my_Rigidbody.velocity);
        
        if (!Input.anyKey)
        {

            if (my_Rigidbody.velocity.x < 1 && my_Rigidbody.velocity.x > -1)
            {

                float now_velocity_y = my_Rigidbody.velocity.y;
                float now_velocity_z = my_Rigidbody.velocity.z;

                my_Rigidbody.velocity = new Vector3(0,now_velocity_y,now_velocity_z);
                


            }
            else
            {
                force = new Vector3(my_Rigidbody.velocity.x * -0.4f, 0, 0);
            }

        }
        

        force.y = -gravity;

        if (Input.GetKeyUp(KeyCode.Space) && transform.position.y <= 2)
        {
            
            force += new Vector3(0, jumpVector, 0);
           
        }

        my_Rigidbody.AddForce(force, ForceMode.Acceleration);
        

    }



    private void FixedUpdate()
    {

        my_Transform.position += new Vector3(0, 0,my_forward_speed);
       

    }

}
    
