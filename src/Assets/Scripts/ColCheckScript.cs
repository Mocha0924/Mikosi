using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColCheckScript : MonoBehaviour
{
    [SerializeField] UnityEvent foodHit;

    [SerializeField] UnityEvent carHit;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            Destroy(other.gameObject);
            foodHit.Invoke();
        }
        if (other.gameObject.tag == "Car")
        {
            carHit.Invoke();
        }
    }
}