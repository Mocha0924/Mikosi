using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector3 eSpawner;
    [SerializeField] int eSpawnCount;

    [SerializeField] GameObject food;
    [SerializeField] Vector3 fSpawner;
    int fSpawnCount = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Spawn(enemy, eSpawner, eSpawnCount);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Spawn(food, fSpawner, fSpawnCount);
        }

    }

    void Spawn(GameObject obj, Vector3 spawner, int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(obj, spawner, Quaternion.identity);
        }
    }
}
