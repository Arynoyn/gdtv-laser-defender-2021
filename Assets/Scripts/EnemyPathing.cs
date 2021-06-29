using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _movementSpeed = 2f;

    private int _currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _waypoints[_currentWaypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovementAlongPath();
    }

    private void CalculateMovementAlongPath()
    {
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
