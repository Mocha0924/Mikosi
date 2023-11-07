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
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] WasshoiSounds;
    [SerializeField] private MikoshiCollisionDetection MikoshiCollision;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MCD = GetComponent<MikoshiCollisionDetection>();
        stamina_script = GetComponent<stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        Input_washoi = Input.GetAxis("Fire1");
        Input_washoi_once = old_washoi - Input_washoi;

        old_washoi = Input_washoi;

        if (Input_washoi_once == -1 && stamina_script.stamina_number_now != 0&&MikoshiCollision.playerMode==MikoshiCollisionDetection.PlayerMode.Play||
            Input_washoi_once == -1 && MikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus)
        {
            for (int i = 0; i < 2; i++)
            {
                audioSource.PlayOneShot(WasshoiSounds[i]);
            }
          

            stamina_script.slider_clone[stamina_script.stamina_number_now - 1].value = 1 - stamina_script.slide_value;

            if (stamina_script.stamina_number_now != 1) { stamina_script.stamina_number_now--; }



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



