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
   
    public void LoadPlus(GameObject Load)
    {
        Load_List.Add(Load);
    }
    public void LoadReduce()
    {
        Load_List.RemoveAt(0);
    }
    private void Update()
    {
        if(Load_List.Count >= 3)
        {
            GameObject DestroyLode = Load_List[0];
            LoadReduce();
            LoadController controller = DestroyLode.GetComponent<LoadController>();
            for(int i = 0; i <controller.PeopleList.Count;i++)
                Destroy(controller.PeopleList[i]);

            Destroy(DestroyLode);
            
        }
    }
  
   
}
