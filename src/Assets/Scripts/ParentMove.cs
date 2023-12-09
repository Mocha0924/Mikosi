using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMove : MonoBehaviour
{
    GameObject parent;
    float childCount;
    Rigidbody rigidbody;
    Vector3 firstPos;
    Vector3 pos;
    player p;

    bool isJump;
    bool isRightSride;
    bool isLeftSride;
    Vector3 velocty;

    float Input_Horizontal;
    float old_Horizontal;
    float Input_Vertical;
    float old_Vertical;
    float Input_Jump;
    float old_Jump;

    // Start is called before the first frame update
    void Start()
    {
        childCount = this.gameObject.transform.parent.childCount - 1;
        Debug.Log("AfterPeople:" + childCount);
        rigidbody = this.GetComponent<Rigidbody>();
        p = GetComponent<player>();

        isJump = false;
        isRightSride = false;
        isLeftSride = false;
        velocty = new Vector3(0, 10f, 0);
        pos = Vector3.zero;
        firstPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Input_Horizontal = Input.GetAxis("Horizontal");
        Input_Vertical = Input.GetAxis("Vertical");
        Input_Jump = Input.GetAxis("Jump");

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            isJump = true;
            Invoke("Jump", childCount);
        }

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    isRightSride = true;
        //    Invoke("RSride", childCount);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    isLeftSride = true;
        //    Invoke("LSride", childCount);
        //}

        if (isRightSride == false && isLeftSride == false)
        {
            pos = this.transform.localPosition;
            pos.x = 0;
            this.transform.localPosition = pos;
        }

        pos = this.transform.localPosition;
        pos.z = firstPos.z;
        this.transform.localPosition = pos;

    }

    void Jump()
    {
        Debug.Log("Jump" + childCount);

        rigidbody.velocity = velocty;

        isJump = false;
    }

    void RSride()
    {
        Debug.Log("RSride" + childCount);
    }

    void LSride()
    {
        Debug.Log("LSride" + childCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        isJump= false;
    }
}
