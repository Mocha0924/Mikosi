using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    Rigidbody my_Rigidbody;
    Transform my_Transform;
    Vector3 force;
    Vector3 pos;
    LoadController load;
    stamina stamina_script;
    string Horizon_move;
    public float my_Thrust = 20f;
    public float my_Thrust_Max = 20f;
    public float my_forward_speed = 1f;
    public float jumpVector = 100f;
    public float gravity = 20f;
    [SerializeField] private float BonusMagnification;
   
    [SerializeField] float slide_power = 2f;
    float Input_Horizontal;
    float old_Horizontal;
    float Input_Jump;
    float old_Jump;
    public float Input_Jump_once;





    public bool turn_complete_R = false;
    public bool turn_complete_L = false;
    [SerializeField] int Turn_speed = 1;
    float turn_times = 0f;

    [SerializeField] private TurnSlider turnSlider;
    [SerializeField] private CameraController cameraController;
    private MikoshiCollisionDetection mikoshiCollision;

    private AudioSource audioSource;
    [SerializeField] private SEController SE;
    [SerializeField] private AudioClip[] JumpSounds;
    [SerializeField] private AudioClip TurnSound;

    private bool turnSoundCheck = false;
    public enum playerType
    {
        Up,
        Right,
        Down,
        Left
    }
    public playerType Angle;

    int Horizontal_controll;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        my_Rigidbody = GetComponent<Rigidbody>();
        my_Transform = GetComponent<Transform>();
        mikoshiCollision = GetComponent<MikoshiCollisionDetection>();
        stamina_script = GetComponent<stamina>();

        pos = transform.position;

    }



    void Update()
    {
     
        Input_Horizontal = Input.GetAxis("Horizontal");
        Input_Jump = Input.GetAxis("Jump");

        Input_Jump_once = old_Jump - Input_Jump;


        if (Input_Horizontal - old_Horizontal > 0) { Horizontal_controll = 1; }
        else if (Input_Horizontal - old_Horizontal < 0) { Horizontal_controll = -1; }
        else if ((Input_Horizontal < 1 && Input_Horizontal > -1)) { Horizontal_controll = 0; }

        //Debug.Log(Horizon_move);

        Horizon_move = Horizontal_Contlroll(old_Horizontal, Input_Horizontal);

        if(!turn_complete_R&&!turn_complete_L)
        {
            switch(Angle)
            {
                case playerType.Up:
                    {

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

                        break;
                    }

                case playerType.Down:
                    {

                        if (Horizon_move == "leftmove")
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
                        else if (Horizon_move == "rightmove")
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

                        break;
                    }

                case playerType.Left:
                    {

                        if (Horizon_move == "leftmove")
                        {

                            if (my_Rigidbody.velocity.z > -my_Thrust_Max)
                            {
                                force = new Vector3(0, 0, -my_Thrust);
                            }
                            else
                            {
                                force = new Vector3(0, 0, 0);

                            }
                        }
                        else if (Horizon_move == "rightmove")
                        {


                            if (my_Rigidbody.velocity.z < my_Thrust_Max)
                            {
                                force = new Vector3(0, 0, my_Thrust);
                            }
                            else
                            {
                                force = new Vector3(0, 0, 0);
                            }
                        }
                        else
                        {

                            if (my_Rigidbody.velocity.z < 3 && my_Rigidbody.velocity.z > -3)
                            {

                                float now_velocity_y = my_Rigidbody.velocity.y;
                                float now_velocity_x = my_Rigidbody.velocity.x;

                                my_Rigidbody.velocity = new Vector3(now_velocity_x, now_velocity_y, 0);



                            }
                            else
                            {
                                force = new Vector3(0, 0, my_Rigidbody.velocity.z * -slide_power);
                            }

                        }

                        break;
                    }

                case playerType.Right:
                    {

                        if (Horizon_move == "leftmove")
                        {

                            if (my_Rigidbody.velocity.z < my_Thrust_Max)
                            {
                                force = new Vector3(0, 0, my_Thrust);
                            }
                            else
                            {
                                force = new Vector3(0, 0, 0);
                            }
                        }
                        else if (Horizon_move == "rightmove")
                        {


                            if (my_Rigidbody.velocity.z > -my_Thrust_Max)
                            {
                                force = new Vector3(0, 0, -my_Thrust);
                            }
                            else
                            {
                                force = new Vector3(0, 0, 0);

                            }
                        }
                        else
                        {

                            if (my_Rigidbody.velocity.z < 3 && my_Rigidbody.velocity.z > -3)
                            {

                                float now_velocity_y = my_Rigidbody.velocity.y;
                                float now_velocity_x = my_Rigidbody.velocity.x;

                                my_Rigidbody.velocity = new Vector3(now_velocity_x, now_velocity_y, 0);



                            }
                            else
                            {
                                force = new Vector3(0, 0, my_Rigidbody.velocity.z * -slide_power);
                            }

                        }

                        break;
                    }
            }
                 
             
        }
        

        force.y = -gravity;

       

        if (mikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Play||
            mikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus)
        {
            if (Input_Jump_once == -1 && transform.position.y <= 2 && stamina_script.stamina_number_now != 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    audioSource.PlayOneShot(JumpSounds[i]);
                }

                float now_velocity_x = my_Rigidbody.velocity.x;
                float now_velocity_z = my_Rigidbody.velocity.z;
                my_Rigidbody.velocity = new Vector3(now_velocity_x, jumpVector, now_velocity_z);

                stamina_script.slider_clone[stamina_script.stamina_number_now - 1].value = 1 - stamina_script.slide_value;

                if (stamina_script.stamina_number_now != 1) { stamina_script.stamina_number_now--; }

            }
            force *= Time.deltaTime;
            my_Rigidbody.AddForce(force, ForceMode.Acceleration);

            old_Horizontal = Input_Horizontal;
            old_Jump = Input_Jump;
        }
       


    }

    private void FixedUpdate()
    {
        if (turn_complete_R)
        {
            if(!turnSoundCheck)
            {
                SE.StopSound();
                turnSoundCheck = true;
                audioSource.PlayOneShot(TurnSound);
            }
            turn_times += Turn_speed;

            transform.rotation = Quaternion.Euler(0, turn_times, 0);

            if (turn_times % 90 == 0)
            {
                turn_complete_R = false;
                turnSoundCheck = false;
                turnSlider.RightTurnEnd();
            }
            if (mikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus)
                my_Transform.position += transform.forward * (my_forward_speed  * 0.5f);
            else if (mikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Play)
                my_Transform.position += transform.forward * (my_forward_speed * 0.5f);
        }
        else if (turn_complete_L)
        {
            if (!turnSoundCheck)
            {
                SE.StopSound();
                turnSoundCheck = true;
                audioSource.PlayOneShot(TurnSound);
            }
            turn_times -= Turn_speed;

            transform.rotation = Quaternion.Euler(0, turn_times, 0);

            if (turn_times % 90 == 0)
            {
                turn_complete_L = false;
                turnSoundCheck = false;
                turnSlider.LeftTurnEnd();
            }
            if (mikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus)
                my_Transform.position += transform.forward * (my_forward_speed *  0.4f);
            else if (mikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Play)
                my_Transform.position += transform.forward * (my_forward_speed * 0.5f);
        }
        else if(mikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus)
            my_Transform.position += transform.forward * (my_forward_speed * ((mikoshiCollision.peopleCount / 10) * 0.05f + 1)*BonusMagnification);
        else if (mikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Play)
            my_Transform.position += transform.forward * (my_forward_speed * ((mikoshiCollision.peopleCount / 10) * 0.05f + 1));


        //my_Transform.position += new Vector3(0, 0, my_forward_speed);


    }

    string Horizontal_Contlroll(float old, float input)
    {

        string Horizon_move = "0";


        if (old > Input_Horizontal)
        {
            if (Input_Horizontal > 0) { Horizon_move = "dontmove"; }
            else { Horizon_move = "leftmove"; }
        }
        else if (old < Input_Horizontal)
        {
            if (Input_Horizontal < 0) { Horizon_move = "dontmove"; }
            else { Horizon_move = "rightmove"; }
        }
        else if (old == Input_Horizontal)
        {
            if (input == 0) { Horizon_move = "dontmove"; }
            else if (input < 0) { Horizon_move = "leftmove"; }
            else if (input > 0) { Horizon_move = "rightmove"; }

        }

        return Horizon_move;


    }

}
