using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPeopleMoveScript : MonoBehaviour
{
    [SerializeField] Vector3 point;

   // [SerializeField] Vector3 goPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = point - transform.localPosition;
        if (diff.magnitude > 1f)
        {
            transform.localRotation = Quaternion.LookRotation(diff); 
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(this.transform.localRotation, Quaternion.Euler(0, 0, 0), 10*Time.deltaTime);
        }
        // Move();
    }

    public void Move()
    {
        //this.transform.localPosition = point;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,point, 10.0f*Time.deltaTime);
        transform.DOLocalMove(point, 10);
    }

    public void Setpoint(Vector3 setPos)
    {
        Debug.Log(this.name + "setPos:" + setPos);
        point = setPos;
        transform.DOLocalMove(point, 1);

    }

    public Vector3 GetPoint()
    {
        return point;
    }

    public void FoodDeath()
    {

    }
}
