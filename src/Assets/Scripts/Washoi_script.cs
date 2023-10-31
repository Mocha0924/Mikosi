using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washoi_script : MonoBehaviour
{

    float Input_washoi;
    float old_washoi;
    public float Input_washoi_once;
    [SerializeField] float wasyoi_hankei = 5.0f;

    MikoshiCollisionDetection MCD;
    stamina stamina_script;

    // Start is called before the first frame update
    void Start()
    {
        MCD = GetComponent<MikoshiCollisionDetection>();
        stamina_script = GetComponent<stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        Input_washoi = Input.GetAxis("Fire1");
        Input_washoi_once = old_washoi - Input_washoi;

        old_washoi = Input_washoi;

        if (Input_washoi_once == 1 && stamina_script.stamina_number_now != 0)
        {

           stamina_script.stamina_value[stamina_script.stamina_number_now] = 0;

            if (stamina_script.stamina_number_now != 0) {stamina_script.stamina_number_now--; }



            Check_People();


        }




    }

    private void FixedUpdate()
    {
        

        
    }

    void Check_People()
    {

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, wasyoi_hankei,Vector3.one);

        foreach (var hit in hits)
        {
            if (hit.collider.tag == "People")
            {
                Debug.Log($"検出されたオブジェクト {hit.collider.name}");

                MCD.peopleCount++;
                Destroy(hit.collider.gameObject);

                Debug.Log(MCD.peopleCount);

                //人の生成
                MCD.GenerateMikoshiPeople();

                if (MCD.peopleCount >= MCD.clearConditions && MCD.isFever == false)
                {
                    MCD.isFever = true;
                    MCD.FeverTime();
                }


            }
        }
    }

}



