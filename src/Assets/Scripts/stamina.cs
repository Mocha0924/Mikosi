using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina : MonoBehaviour
{

    [SerializeField] int stamina_number_first = 3;
    public float[] stamina_value;
    public int stamina_number_now;
    int image_number = 0;
    [SerializeField]int stamina_heal_needTime = 5;
    Vector3 stamina_image_pos = new Vector3(800,-400,0);

    float slide_sec_value;
    public float slide_value = 1.0f;

    [SerializeField] Slider stamina_slider;
    //[SerializeField] Image stamina_image;
    //public Image[] image_clone;
    public Slider[] slider_clone;
    [SerializeField] Transform canvas;

    int time = 0;


    // Start is called before the first frame update
    void Start()
    {
        stamina_value = new float[stamina_number_first + 1] ;
        //image_clone = new Image[stamina_number_first] ;
        slider_clone = new Slider[stamina_number_first] ;
        stamina_number_now = stamina_number_first;

        slide_sec_value = 1.0f / stamina_heal_needTime;
        


        Vector3 vectorCanvas = canvas.localPosition + stamina_image_pos * canvas.localScale.x; //キャンパスのScaleに合わせる。


        

        for(int i = 0; i < stamina_number_first; i++)
        {

            //image_clone[i] =  Instantiate(stamina_image, vectorCanvas, Quaternion.identity, canvas);
            slider_clone[i] = Instantiate(stamina_slider, vectorCanvas, Quaternion.identity, canvas);

            vectorCanvas.x -= 100 * canvas.localScale.x;


            

        }
        
        foreach (int stamina in stamina_value)
        {
            stamina_value[stamina] = 1;

            

        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (int stamina in stamina_value)
        {
            
            //Debug.Log(stamina_number_now);
        }


    }

    private void FixedUpdate()
    {
        time++;

        for (int i = 2; i >= stamina_number_now; i--) { Debug.Log(i); slider_clone[i].value = 1; }

        if (time >= 50 )
        {


            slide_value += slide_sec_value;


            slider_clone[stamina_number_now - 1].value = 1 - slide_value;

           
            


           if(slide_value >= 1 && stamina_number_now != 3) { slide_value = 0; }


            


            if (slider_clone[stamina_number_now - 1].value <= 0)
            {

                if (stamina_number_now < stamina_number_first)
                {

                 
                    stamina_number_now++;
                   
                }

            }

            time = 0;
        }

        

    }
}
