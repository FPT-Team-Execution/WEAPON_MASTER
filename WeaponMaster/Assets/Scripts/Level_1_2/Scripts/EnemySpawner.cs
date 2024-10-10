using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;  // The enemy prefab to spawn
	public int enemyCount = 50;     // Number of enemies to spawn
	public Vector3 spawnAreaMin;    // Minimum bounds of the spawn area
	public Vector3 spawnAreaMax;    // Maximum bounds of the spawn area

	void Start()
	{
		SpawnEnemies();
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
