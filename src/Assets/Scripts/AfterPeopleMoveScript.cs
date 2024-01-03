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
        if(point.x >= 0)
        {
            point.x += 10;
        }
        else
            point.x -= 10;
        transform.DOLocalMove(point, 1);
      
        Invoke("DeathPeople",2);
    }
    public void CarHitdeath()
    {
        point += (Vector3.back * 300 + Vector3.up*20);
        transform.DOLocalMove(point, 3);
        Invoke("DeathPeople", 2);
    }
    private void DeathPeople()
    {
        Destroy(gameObject);
    }
}
