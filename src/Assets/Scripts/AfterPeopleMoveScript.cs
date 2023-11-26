using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPeopleMoveScript : MonoBehaviour
{
    [SerializeField] Vector3 point;
    [SerializeField] Vector3 goPoint;
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
        goPoint = destination;
        this.transform.localPosition = goPoint;
    }
}
