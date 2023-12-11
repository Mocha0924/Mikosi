using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentController : MonoBehaviour
{
    private MikoshiCollisionDetection mikoshiCollision;

    private void Start()
    {
        mikoshiCollision = GameObject.Find("Player").GetComponent<MikoshiCollisionDetection>();
    }
    private void Update()
    {
        if(this.gameObject.transform.childCount <=0)
          mikoshiCollision.DestroyParent();
    }
}
