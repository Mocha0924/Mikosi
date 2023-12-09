using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMove : MonoBehaviour
{
    GameObject parent;
    float childCount;
    GameObject target;
    Vector3 offset;
    Vector3 pos;
    player p;
    
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Player");
        //childCount = this.gameObject.transform.parent.childCount - 1;
        //Debug.Log("AfterPeople:" + childCount);
        //Vector3 offset = new Vector3(0f, 0.25f, -0.7f - 0.6f * childCount);
        //Debug.Log(offset);
        p = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        //pos = target.GetComponent<Vector3>();
        //Invoke(nameof(Move), 1);
    }

    void Move()
    {
        //transform.position = pos + offset;
    }
}
