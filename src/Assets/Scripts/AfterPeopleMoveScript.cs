using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPeopleMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 destination)
    {
        Debug.Log("Move:" + destination);
        this.transform.localPosition = destination;
    }
}
