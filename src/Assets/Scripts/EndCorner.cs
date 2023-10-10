using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCorner : MonoBehaviour
{

    public GameObject corner_start;
    player player_script;
    TurnStick TurnStick;
    [SerializeField] GameObject player;
    [SerializeField] int turntimes_complete = 10;

    // Start is called before the first frame update
    void Start()
    {
        TurnStick = corner_start.GetComponent<TurnStick>();
        player_script = player.GetComponent<player>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        TurnStick.in_corner = false;

        if (TurnStick.turn_times >= turntimes_complete)
        {

            if (gameObject.tag == "R") { player_script.turn_complete_R = true; }
            else { player_script.turn_complete_L = true; }

            TurnStick.turn_times = 0;
        }
        else
        {
            Debug.Log("failed");
        }


    }

}
