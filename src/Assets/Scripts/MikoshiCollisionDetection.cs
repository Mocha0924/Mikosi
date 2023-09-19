using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoshiCollisionDetection : MonoBehaviour
{
    [SerializeField] int peopleCount;
    [SerializeField] int clearConditions;
    [SerializeField] bool isFever;


    // Start is called before the first frame update
    void Start()
    {
        peopleCount = 0;
        clearConditions = 100;
        isFever = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFever == false && peopleCount >= clearConditions)
        {
            isFever = true;
            FeverTime();
        }
    }

    //神輿と人の当たり判定(人と当たった時に人を増やす)
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "People")
        {
            peopleCount++;
            Destroy(other.gameObject);
            Debug.Log("People Touch");
            Debug.Log(peopleCount);
        }
    }

    void FeverTime()
    {

    }
}
