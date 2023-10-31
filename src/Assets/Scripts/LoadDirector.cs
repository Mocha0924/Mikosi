using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadDirector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private List<GameObject> Load_List = new List<GameObject>();
    public List<Vector3> PeopleList = new List<Vector3>();
    [SerializeField] private GameObject Load;
    public GameObject StartTurn;
    public int turnCount = 0;
    public int MaxTurnCount;
    public bool turnCheck = false;
    public bool RightTurn = false;
    [SerializeField] private List<GameObject> Patarn_List;
    public List<GameObject> Cource_List;
    public int CourseCount = 0;

    private void Start()
    {
        CourceDecision();
    }
    public void LoadPlus(GameObject Load)
    {
        Load_List.Add(Load);
        CourseCount++;
        if(CourseCount >= Cource_List.Count)
        {
            CourceDecision();
            CourseCount = 0;
        }
    }
    public void LoadReduce()
    {
        Load_List.RemoveAt(0);
    }
    private void Update()
    {
        if(Load_List.Count >= 4)
        {
            GameObject DestroyLode = Load_List[0];
            LoadReduce();
            LoadController controller = DestroyLode.GetComponent<LoadController>();
            for(int i = 0; i <controller.ObjectList.Count;i++)
                Destroy(controller.ObjectList[i]);

            Destroy(DestroyLode);
            
        }
    }
    public void StartTurnLoad(GameObject start)
    {
        StartTurn = start;
    }

    private void CourceDecision()
    {
        Cource_List = Patarn_List;
        for (int i = Cource_List.Count - 1; i > 0; i--)
        {
            var j = Random.Range(0, i + 1);
            var temp = Cource_List[i];
            Cource_List[i] = Cource_List[j];
            Cource_List[j] = temp;
        }
    }



}
