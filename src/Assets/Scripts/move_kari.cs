using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_kari : MonoBehaviour
{

    Transform my_Transform;
    Rigidbody my_Rigidbody;
    [SerializeField] float my_forward_speed = 0.1f;
    Vector3 my_velocity ;

    // Start is called before the first frame update
    void Start()
    {
        my_Transform = GetComponent<Transform>();
        my_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        my_Transform.position += transform.forward * 0.1f;

    }
}
