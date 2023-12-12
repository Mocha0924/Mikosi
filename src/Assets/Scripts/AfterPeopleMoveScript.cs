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
        Move();
    }

    public void Move()
    {
        //this.transform.localPosition = point;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,point, 10.0f*Time.deltaTime);
    }

    public void Setpoint(Vector3 setPos)
    {
        Debug.Log(this.name + "setPos:" + setPos);
        point = setPos;
       
    }

    public Vector3 GetPoint()
    {
        return point;
    }
}
