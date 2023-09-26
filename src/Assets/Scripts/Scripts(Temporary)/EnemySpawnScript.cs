using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector3 spawner;
    [SerializeField] int spawnCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemy,spawner,Quaternion.identity);
        }
    }
}
