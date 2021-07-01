using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _pathPrefab;
    [SerializeField] private float _timeBetweenSpawns = 0.5f;
    [SerializeField] private float _spawnRandomFactor = 0.3f;
    [SerializeField] private int _numberOfEnemies = 5;
    [SerializeField] private float _movementSpeed = 2f;

    public GameObject GetEnemyPrefab() { return _enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform transform in _pathPrefab.transform)
        {
            waypoints.Add(transform);
        }

        return waypoints;
        //return _pathPrefab.Cast<Transform>.ToList(); //Requires Linq
    }
    public float GetTimeBetweenSpawns() { return _timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return _spawnRandomFactor; }
    public int GetNumberOfEnemies() { return _numberOfEnemies; }
    public float GetMovementSpeed() { return _movementSpeed; }
    
}
