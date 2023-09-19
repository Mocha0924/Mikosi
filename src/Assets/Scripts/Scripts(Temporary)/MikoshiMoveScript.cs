using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoshiMoveScript : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float Thrust = 20f;
    Vector3 force;

    private void Start()
    {
        m_Rigidbody=GetComponent<Rigidbody>();
        force = new Vector3(Thrust, 0, 0);
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)) {
            m_Rigidbody.AddForce(force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.AddForce(0, 0, -Thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.AddForce(0, 0, Thrust);
        }
    }
}
