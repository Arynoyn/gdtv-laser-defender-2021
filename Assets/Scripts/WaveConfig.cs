using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _pathPrefab;
    [SerializeField] private float _timeBetweenSpawns = 0.5f;
    [SerializeField] private float _spawnRandomFactor = 0.3f;
    [SerializeField] private int _numberOfEnemies = 5;
    [SerializeField] private float _movementSpeed = 2f;

    public GameObject GetEnemyPrefab() { return _enemyPrefab; }
    public GameObject GetPathPrefab() { return _pathPrefab; }
    public float GetTimeBetweenSpawns() { return _timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return _spawnRandomFactor; }
    public int GetNumberOfEnemies() { return _numberOfEnemies; }
    public float GetMovementSpeed() { return _movementSpeed; }
    
}
