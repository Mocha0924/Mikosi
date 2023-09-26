using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCorner : MonoBehaviour
{

    public GameObject corner_end;
    TurnStick TurnStick;
    [SerializeField] GameObject player;
    bool turn_complete = false;
    float times;
    // Start is called before the first frame update
    void Start()
    {
        TurnStick = corner_end.GetComponent<TurnStick>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        TurnStick.in_corner = false;

        if (TurnStick.turn_times >= 10)
        {

            times = (int)player.transform.rotation.y;
            
            //other.transform.rotation = Quaternion.Euler(0, 90, 0);
            turn_complete = true;
            

        }
        else
        {
            Debug.Log("failed");
        }
    }

    void FixedUpdate()
    {
        Debug.Log(player.transform.);
        if (turn_complete)
        {
            times++;
            
                player.transform.rotation =  Quaternion.Euler(0, times, 0);

            if (times % 90 == 0)
            {
                turn_complete = false;
            }
            
        }

    }


}
