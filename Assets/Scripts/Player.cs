using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Controls.IPlayerActions
{
    private Vector2 _direction;
    [SerializeField] private float _startingVerticalPosition = -8.5f;
    [SerializeField] private float _speed = 5.0f;
    private float _screenLimitLeft;
    private float _screenLimitRight;
    private float _screenLimitTop;
    private float _screenLimitBottom;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3( 0,_startingVerticalPosition, 0);
        InitializeViewBounderies();
    }

    private void InitializeViewBounderies()
    {
        Camera gameCamera = Camera.main;
        var localScale = transform.localScale;
        var playerWidth = localScale.x;
        var playerHeight = localScale.y;
        _screenLimitLeft = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + playerWidth / 2;
        _screenLimitRight = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - playerWidth / 2;
        _screenLimitTop = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - playerHeight / 2;
        _screenLimitBottom = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + playerHeight / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
        float clampedX = Mathf.Clamp(transform.position.x, _screenLimitLeft, _screenLimitRight);
        float clampedY = Mathf.Clamp(transform.position.y, _screenLimitBottom, _screenLimitTop);
        transform.position = new Vector3(clampedX, clampedY, 0);
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
