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
        //Move();
    }

    public void Move()
    {
        this.transform.localPosition = point;
    }

    public void Setpoint(Vector3 setPos)
    {
        Debug.Log(this.name + "setPos:" + setPos);
        point = setPos;
        Move();
    }
}
