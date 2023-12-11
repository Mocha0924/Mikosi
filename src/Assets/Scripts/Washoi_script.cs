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
    [SerializeField] private AudioClip PeopleRecoverySound;
    [SerializeField] private MikoshiCollisionDetection MikoshiCollision;
    [SerializeField] private GameObject Washoi_hani;
    [SerializeField] private float Washoi_Duration = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MCD = GetComponent<MikoshiCollisionDetection>();
        stamina_script = GetComponent<stamina>();

        Washoi_hani.transform.localScale =  new Vector3(wasyoi_hankei,0.01f,wasyoi_hankei);

        Debug.Log(this.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        Input_washoi = Input.GetAxis("Fire1");
        Input_washoi_once = old_washoi - Input_washoi;

        old_washoi = Input_washoi;

        if (Input_washoi_once == -1 && stamina_script.stamina_rest > 0&&MikoshiCollision.playerMode==MikoshiCollisionDetection.PlayerMode.Play||
            Input_washoi_once == -1 && MikoshiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus)
        {
            for (int i = 0; i < 2; i++)
            {
                audioSource.PlayOneShot(WasshoiSounds[i]);
            }

            Destroy(Instantiate(Washoi_hani, this.transform, false), Washoi_Duration);

            stamina_script.slider_clone[stamina_script.stamina_number_now - 1].value = 1 - stamina_script.slide_value;
            stamina_script.stamina_rest--;

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
                audioSource.PlayOneShot(PeopleRecoverySound);
                Debug.Log("People Touch");

                MCD.peopleCount++;
                MCD.PeopleNumText.text = (MCD.peopleCount - 6).ToString("") + "人神輿";
                MCD.behindPeopleCount = MCD.peopleCount - 18;
                if (MCD.behindPeopleCount % 9 == 1)
                {
                    //列に9人いる時、列を増やす
                    MCD.behindPeopleRow--;
                    MCD.GenerateParent(1);
                }

                Destroy(hit.collider.gameObject);

                Debug.Log(MCD.peopleCount);

                //人の生成
                MCD.GenerateMikoshiPeople(hit.transform.position);

                if (MCD.peopleCount - 6 >= MCD.clearConditions && MCD.isFever == false)
                {
                    MCD.isFever = true;
                    MCD.FeverTime();
                }
            }

        }


    }

}



