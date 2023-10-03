using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
public class LoadController : MonoBehaviour
{
    [SerializeField] private GameObject center;
    public  GameObject end;
    public  GameObject begin;
    public  GameObject Left;
    public  GameObject Right;
    [SerializeField] private GameObject Load;
    [SerializeField] GameObject people;
    [SerializeField] GameObject food;
    [SerializeField] private LoadDirector Director;
    private Vector3 SpawnPosition = Vector3.zero;
    private List<Vector3> CoodinateList = new List<Vector3>();
    public List<GameObject> ObjectList = new List<GameObject>();
         

    private void Start()
    {
        Director.LoadPlus(this.gameObject);
        PeopleListGenerator();
        Generation();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Quaternion LoadRotate = gameObject.transform.rotation;
            Instantiate(Load, end.gameObject.transform.position, LoadRotate);
           
        }
       
    }
    private void PeopleListGenerator()
    {
        List<float> LoadX = new List<float>();
        List<float> LoadZ = new List<float>();
        for (float i =Left.transform.position.x; i <= Right.transform.position.x; i++)
        {
            LoadX.Add(i);
            // Debug.Log("X"+ i);
        }


        for (float i = begin.transform.position.z; i < end.transform.position.z; i++)
        {
            LoadZ.Add(i);
            // Debug.Log("Z" + i);
        }

        for (int i = 0; i < LoadX.Count; i++)
        {
            for (int j = 0; j < LoadZ.Count; j++)
            {
                CoodinateList.Add(new Vector3(LoadX[i], Load.transform.position.y + Load.transform.localScale.y, LoadZ[j]));
            }
        }
        for (int i = CoodinateList.Count - 1; i > 0; i--)
        {
            var j = Random.Range(0, i + 1);
            var temp = CoodinateList[i];
            CoodinateList[i] = CoodinateList[j];
            CoodinateList[j] = temp;
        }
    }
    public void Generation()
    {
        int rand = Random.Range(10, 20);
        for (int i = 0; i < rand; i++)
        {
            GameObject PeoplePre =  Instantiate(people, CoodinateList[i], Quaternion.identity);
            ObjectList.Add(PeoplePre);
        }
        for (int i = 0; i < 20; i++)
        {
            GameObject FoodPre = Instantiate(food, CoodinateList[i], Quaternion.identity);
            ObjectList.Add(FoodPre);
        }
    }

}
