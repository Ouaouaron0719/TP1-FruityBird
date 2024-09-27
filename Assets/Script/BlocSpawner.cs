using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocSpawner : MonoBehaviour
{
    public GameObject BlocPrefab; 
    public float spawnInterval = 2f; 
    //public float spawnHeightRange = 3f; 
    public float spawnXPosition = 8.5f; 

    void Start()
    {
        
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        
        float randomY = Random.Range(-0.28f, 1.55f);

        
        Vector3 spawnPosition = new Vector3(spawnXPosition, randomY, 0);
        Instantiate(BlocPrefab, spawnPosition, Quaternion.identity);
    }
}
