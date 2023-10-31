using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina : MonoBehaviour
{

    [SerializeField] int stamina_number_first = 3;
    public int[] stamina_value;
    public int stamina_number_now;
    int image_number = 0;
    [SerializeField]int stamina_heal_needTime = 5;
    Vector3 stamina_image_pos = new Vector3(1840,80,0);


    [SerializeField] Image stamina_image;
    public Image[] image_clone;
    [SerializeField] Transform canvas;

    int time = 0;


    // Start is called before the first frame update
    void Start()
    {
        stamina_value = new int[stamina_number_first + 1] ;
        image_clone = new Image[stamina_number_first] ;
        stamina_number_now = stamina_number_first;


        foreach (int stamina in stamina_value)
        {
            stamina_value[stamina] = 0;
        }

        for(int i = 0; i < stamina_number_first; i++)
        {

            image_clone[i] =  Instantiate(stamina_image, stamina_image_pos, Quaternion.identity, canvas);

            stamina_image_pos.x -= 100;

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

                    image_clone[stamina_number_now ].color = new Color(1,1,0);
                    stamina_value[stamina_number_now] = 0;
                    stamina_number_now++;
                   
                }

            }

            time = 0;
        }

        

    }
}
