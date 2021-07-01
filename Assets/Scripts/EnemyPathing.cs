using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private WaveConfig _waveConfig;
    [SerializeField] private float _movementSpeed = 2f;
    private List<Transform> _waypoints;

    private int _currentWaypointIndex = 0;

    void Start()
    {
        if (_waveConfig == null)
        {
            Debug.LogError("Wave Config is null on Enemy Pathing!");
        }
        else
        {
            _waypoints = _waveConfig.GetWaypoints();
            transform.position = _waypoints[_currentWaypointIndex].transform.position;
        }
    }

    void Update()
    {
        CalculateMovementAlongPath();
    }

    private void CalculateMovementAlongPath()
    {
        if (_waypoints == null || !_waypoints.Any()) return;
        if (_currentWaypointIndex < _waypoints.Count)
        {
            var targetPosition = _waypoints[_currentWaypointIndex].transform.position;
            var movementThisFrame = _movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                _currentWaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
