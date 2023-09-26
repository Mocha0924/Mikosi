using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    [SerializeField] private GameObject center;
    [SerializeField] private GameObject end;
    [SerializeField] private GameObject begin;
    [SerializeField] private GameObject Load;
    [SerializeField] private GameObject Player;
    [SerializeField] private LoadDirector Director;
    private Vector3 SpawnPosition = Vector3.zero;

    private void Start()
    {
        Director.LoadPlus(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Quaternion LoadRotate = gameObject.transform.rotation;
            Instantiate(Load, end.gameObject.transform.position, LoadRotate);
        }
       
    }
}
