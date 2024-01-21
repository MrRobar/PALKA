using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawnManager : MonoBehaviour {
	[SerializeField] private EnemySpawner spawnerPrefab;
	[SerializeField] private List<EnemySpawner>enemySpawners;
	[SerializeField] private int minSpawnPointsAmount, maxSpawnPointsAmount;
	[SerializeField] private float minDistanceBetweenPlayerAndSpawnPoint;
	[SerializeField] private float maxDistanceBetweenPlayerAndSpawnPoint;


	[ContextMenu("SpawnPoints")]
	void SetupSpawnPoints() {
		int randSpawnAmount = Random.Range(minSpawnPointsAmount, maxSpawnPointsAmount);
		var pointsParent = new GameObject("SpawnerPointsParent");
		Transform playerTransform = PlayerKeeper.Instance.GetPlayerTransform();

		
		for (int i = 0; i < randSpawnAmount; i++) {
			Vector3 spawnPosition = GetRandomSpawnPosition(playerTransform);
			var spawner = Instantiate(spawnerPrefab, spawnPosition, Quaternion.identity);
			spawner.Init(playerTransform);
			
			enemySpawners.Add(spawner);
			spawner.transform.parent = pointsParent.transform;
		}
	}
	private Vector3 GetRandomSpawnPosition(Transform playerTransform) {
		Vector3 randomDirection = Random.insideUnitSphere * Random.Range(minDistanceBetweenPlayerAndSpawnPoint, maxDistanceBetweenPlayerAndSpawnPoint);
		randomDirection.y = 0f;
		Vector3 spawnPosition = playerTransform.position + randomDirection;
		return spawnPosition;
	}
	[ContextMenu("SpawnEnemies")]
	void StartSpawning() {
		foreach (var spawner in enemySpawners) {
			spawner.Spawn();
		}
	}
}
