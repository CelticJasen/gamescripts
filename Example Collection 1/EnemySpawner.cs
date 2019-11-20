using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Enemy[] enemies;
	[SerializeField] private float delay = 2f;
	[SerializeField] private int maxSpawnedEnemies = 2;

	private int currentSpawnedEnemies = 0;

	private void Start()
	{
		InvokeRepeating ("SpawnEnemy", 0, delay);
	}

	private void SpawnEnemy()
	{
		if (currentSpawnedEnemies >= maxSpawnedEnemies)
		{
			return;
		}

		var spawnedEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation) as Enemy;
		currentSpawnedEnemies++;
		spawnedEnemy.Health.events.onDie.AddListener (HandleEnemyDied);
	}

	private void HandleEnemyDied()
	{
		currentSpawnedEnemies--;
	}
}