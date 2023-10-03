using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_kari : MonoBehaviour
{

    Transform my_Transform;

    [SerializeField] float foward_speed = 0.1f;

    public bool turn_complete_R = false;
    public bool turn_complete_L = false;
    [SerializeField] int Turn_speed = 1;
    float times = 0f;



    // Start is called before the first frame update
    void Start()
    {
        my_Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        my_Transform.position += transform.forward * foward_speed;



        if (turn_complete_R)
        {
            times += Turn_speed ;

            transform.rotation = Quaternion.Euler(0, times, 0);

            if (times % 90 == 0)
            {
                turn_complete_R = false;
            }
        }
        else if(turn_complete_L)
        {
            times += Turn_speed ;

            transform.rotation = Quaternion.Euler(0, -times, 0);

            if (times % 90 == 0)
            {
                turn_complete_L = false;
            }
        }
    }
}
