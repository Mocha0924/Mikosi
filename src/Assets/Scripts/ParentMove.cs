using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMove : MonoBehaviour
{
    GameObject parent;
    int childCount;

    // Start is called before the first frame update
    void Start()
    {
        childCount = this.gameObject.transform.parent.childCount - 1;
        Debug.Log("AfterPeople:" + childCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
