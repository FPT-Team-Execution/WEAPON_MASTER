using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn
    public int enemyCount = 1;     // Number of enemies to spawnpublic GameObject enemyPrefab;  
    public Vector3 spawnAreaMin;    // Minimum bounds of the spawn area
    public Vector3 spawnAreaMax;    // Maximum bounds of the spawn area


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }
}
