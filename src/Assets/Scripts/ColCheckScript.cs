using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColCheckScript : MonoBehaviour
{
    [SerializeField] UnityEvent foodHit;

    [SerializeField] UnityEvent carHit;

    [SerializeField] private CameraController cameracontroller;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            if(foodHit != null)
            {
                Destroy(other.gameObject);
                foodHit.Invoke();
            }
            
        }
        if (other.gameObject.tag == "Car")
        {
            if(carHit!=null)
            {
                carHit.Invoke();
            }
           
        }
    }
}
