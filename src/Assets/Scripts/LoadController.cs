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
    [SerializeField] private GameObject TurnLoad;
    [SerializeField] private GameObject EndTurnLoad;
    [SerializeField] GameObject people;
    [SerializeField] GameObject food;
    [SerializeField] private LoadDirector Director;
    private Vector3 SpawnPosition = Vector3.zero;
    private List<Vector3> CoodinateList = new List<Vector3>();
    public List<GameObject> ObjectList = new List<GameObject>();
    public GameObject TurnStartLoad;
    Quaternion LoadRotate;
    public enum LoadType
    { 
        Up,
        Right,
        Down,
        Left
    }
    public LoadType Angle;

    private void Start()
    {
        Director = GameObject.Find("LoadDirector").GetComponent<LoadDirector>();
        Director.LoadPlus(this.gameObject);
        PeopleListGenerator();
        Generation();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
      
            if(Director.turnCheck)
            {
                TurnStartLoad = this.gameObject;
                Director.StartTurnLoad(TurnStartLoad);
                LoadRotate = gameObject.transform.rotation;
                Quaternion q = Quaternion.Euler(0f, 90f, 0f);
                LoadRotate*=q;
                GameObject newLoad = Instantiate(EndTurnLoad, end.gameObject.transform.position, LoadRotate);
                LoadController loadcontroller = newLoad.GetComponent<LoadController>();
                loadcontroller.Angle = Angle+1;
                Director.turnCheck = false;
                Director.turnCount = 0;
            }
            else if (Director.turnCount >= 0)
            {
                LoadRotate = gameObject.transform.rotation;
                GameObject newLoad =  Instantiate(TurnLoad, end.gameObject.transform.position, LoadRotate);
                LoadController loadcontroller = newLoad.GetComponent<LoadController>();
                loadcontroller.Angle = Angle;
                Director.turnCheck = true;

            }
            else
            {
                LoadRotate = gameObject.transform.rotation;
                GameObject newLoad = Instantiate(Load, end.gameObject.transform.position, LoadRotate);
                LoadController loadcontroller = newLoad.GetComponent<LoadController>();
                loadcontroller.Angle = Angle;
                Director.turnCount++;
            }
           
           
        }
       
    }
    private void PeopleListGenerator()
    {
        List<float> LoadX = new List<float>();
        List<float> LoadZ = new List<float>();
        switch (Angle)
        {
            case LoadType.Up:
                {
                    for (float i = Left.transform.position.x; i <= Right.transform.position.x; i++)
                    {
                        LoadX.Add(i);
                    }


                    for (float i = begin.transform.position.z; i < end.transform.position.z; i++)
                    {
                        LoadZ.Add(i);
                    }
                    break;
                }
            case LoadType.Right:
                {
                    for (float i = Left.transform.position.z; i >= Right.transform.position.z; i--)
                    {
                        LoadX.Add(i);
                    }


                    for (float i = begin.transform.position.x; i < end.transform.position.x; i++)
                    {
                        LoadZ.Add(i);
                    }
                    break;
                }
            case LoadType.Down:
                {
                    for (float i = Left.transform.position.x; i >= Right.transform.position.x; i--)
                    {
                        LoadX.Add(i);
                    }


                    for (float i = begin.transform.position.z; i > end.transform.position.z; i--)
                    {
                        LoadZ.Add(i);
                    }
                    break;
                }
            case LoadType.Left:
                {
                    for (float i = Left.transform.position.z; i <= Right.transform.position.z; i++)
                    {
                        LoadX.Add(i);
                    }


                    for (float i = begin.transform.position.x; i > end.transform.position.x; i--)
                    {
                        LoadZ.Add(i);
                    }
                    break;
                }
        }

       if(Angle==LoadType.Up||Angle==LoadType.Down)
        {
            for (int i = 0; i < LoadX.Count; i++)
            {
                for (int j = 0; j < LoadZ.Count; j++)
                {
                    CoodinateList.Add(new Vector3(LoadX[i], Load.transform.position.y + 1.3f + Load.transform.localScale.y, LoadZ[j]));
                }
            }
        }
        else
        {
            for (int i = 0; i < LoadZ.Count; i++)
            {
                for (int j = 0; j < LoadX.Count; j++)
                {
                    CoodinateList.Add(new Vector3(LoadZ[i], Load.transform.position.y + 1.3f + Load.transform.localScale.y, LoadX[j]));
                }
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
        for (int i = rand ; i < 10+rand; i++)
        {
            GameObject FoodPre = Instantiate(food, CoodinateList[i], Quaternion.identity);
            ObjectList.Add(FoodPre);
        }
    }

}
