using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadDirector : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> Load_List = new List<GameObject>();
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
            GameObject DestroyLoad = Load_List[0];
            LoadReduce();
            Destroy(DestroyLoad);
            
        }
    }
}
