using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamina : MonoBehaviour
{

    const int stamina_number_first = 3;
    int[] stamina_value;
    int stamina_number_now = 2;
    int stamina_heal_sec = 5;
    int time = 0;

    Washoi_script washoi_Script;
    player player;


    // Start is called before the first frame update
    void Start()
    {

        washoi_Script = GetComponent<Washoi_script>();
        player = GetComponent<player>();

        stamina_value = new int[stamina_number_first] ;
        
        foreach(int stamina in stamina_value)
        {
            stamina_value[stamina] = stamina_heal_sec;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.Input_Jump_once == 1)
        {
            stamina_value[stamina_number_now] -= stamina_heal_sec;
            if (stamina_number_now != 0) { stamina_number_now--; }
        }

        if (washoi_Script.Input_washoi_once == 1)
        {
            stamina_value[stamina_number_now] -= stamina_heal_sec;

            if (stamina_number_now != 0) { stamina_number_now--; }


        }

        Debug.Log(stamina_number_now);


    }



    private void FixedUpdate()
    {
        time++;

        if(time >= 200 )
        {
            stamina_value[stamina_number_now] += 1;
            if (stamina_number_now < 2) { stamina_number_now++; }

            time = 0;
        }


    }
}
