using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamina : MonoBehaviour
{

    [SerializeField] int stamina_number_first = 3;
    public int[] stamina_value;
    public int stamina_number_now;
    [SerializeField]int stamina_heal_needTime = 5;
    int time = 0;


    // Start is called before the first frame update
    void Start()
    {
        stamina_value = new int[stamina_number_first + 1] ;
        stamina_number_now = stamina_number_first;


        foreach (int stamina in stamina_value)
        {
            stamina_value[stamina] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void FixedUpdate()
    {
        time++;

        if(time >= 50 )
        {
            
            stamina_value[stamina_number_now] += 1;

            if (stamina_value[stamina_number_now] == stamina_heal_needTime)
            {              
                if (stamina_number_now < stamina_number_first)
                {
                    stamina_value[stamina_number_now] = 0;
                    stamina_number_now++;
                   
                }

            }

            time = 0;
        }


    }
}
