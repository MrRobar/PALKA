using System;
using UnityEngine;
public class EnemySpawner : MonoBehaviour {
	[SerializeField] private Enemy enemyPrefab;
	[SerializeField] private Transform spawnPoint;

	private Transform _targetTransform;

	public void Init(Transform targetTransform) {
		_targetTransform = targetTransform;
	}

	public void Spawn() {
		Enemy e = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
		e.Init(_targetTransform);
	}
}
