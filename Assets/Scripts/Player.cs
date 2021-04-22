using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Controls.IPlayerActions
{
    private Vector2 _direction;
    [SerializeField] float _startingVerticalPosition = -8.5f;
    [SerializeField] private float _speed = 5.0f;
    float _screenLimitLeft = -5.15f;
    float _screenLimitRight = 5.15f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3( 0,_startingVerticalPosition, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
        float clampedX = Mathf.Clamp(transform.position.x, _screenLimitLeft, _screenLimitRight);
        transform.position = new Vector3(clampedX, transform.position.y, 0);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
