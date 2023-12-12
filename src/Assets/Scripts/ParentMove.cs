using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static player;

public class ParentMove : MonoBehaviour
{
    GameObject parent;
    float childCount;
    float call;
    Rigidbody my_Rigidbody;
    Vector3 firstPos;
    GameObject Player;
    player p;

    Vector3 velocty;
    Vector3 force;
    float slide_power;

    int Horizontal_controll;
    float jumpVec;
    float Input_Horizontal;
    float old_Horizontal;
    float Input_Jump;
    float old_Jump;
    float Input_Jump_once;

    stamina stamina_Script;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        childCount = this.gameObject.transform.parent.childCount - 1;
        call = childCount / 4;
        Debug.Log("AfterPeople:" + childCount);
        my_Rigidbody = this.GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
        p = Player.GetComponent<player>();

        velocty = new Vector3(0, 10f, 0);
        jumpVec = 10f;
        slide_power = 2f;
        firstPos = this.transform.localPosition;

        stamina_Script = Player.GetComponent<stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        Input_Horizontal = Input.GetAxis("Horizontal");
        Input_Jump = Input.GetAxis("Jump");

        Input_Jump_once = old_Jump - Input_Jump;
        //Debug.Log("o:"+old_Jump)

        if (Input_Jump_once == -1
            && transform.position.y <= 2
            && stamina_Script.stamina_rest > 0)
        {
            Invoke("Jump", call);
        }

        //forceÇÃê›íË

        //force *= Time.deltaTime;
        //StartCoroutine(Sride(p.force));

        pos = this.transform.localPosition;
        pos.x = 0;
        pos.z = firstPos.z;
        this.transform.localPosition = pos;

        old_Horizontal = Input_Horizontal;
        //old_Jump = Input_Jump;
    }

    void Jump()
    {
        //Debug.Log("Jump" + childCount);

        velocty = my_Rigidbody.velocity;
        velocty.y = jumpVec;
        my_Rigidbody.velocity = velocty;
    }

    IEnumerator Sride(Vector3 Force)
    {
        yield return call*10;
        //Debug.Log("Sride" + childCount);
        my_Rigidbody.AddForce(Force, ForceMode.Acceleration);
    }
}
