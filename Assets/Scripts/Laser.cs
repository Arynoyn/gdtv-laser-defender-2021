using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            Debug.LogError("Rigid Body is NULL in Laser");
        }
        else
        {
            rigidBody.velocity = new Vector2(0, _movementSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
