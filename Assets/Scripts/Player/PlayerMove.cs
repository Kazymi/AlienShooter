using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour,IChangeSpeed
{
    private InputHandler _inputHandler;
    private CharacterController _characterController;
    private float _speed;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void Initialize(PlayerConfiguration playerConfiguration, InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
        _speed = playerConfiguration.Speed;
    }

    private void Move()
    {
        float _currentSpeed = _speed > 0 ? _speed : 0;
        var moveDir = new Vector3(_inputHandler.MoveDirection.x, 0, _inputHandler.MoveDirection.y);
        moveDir = transform.TransformDirection(moveDir);
        moveDir *= _currentSpeed * Time.deltaTime;
        _characterController.Move(moveDir);
    }

    public void AddSpeed(float valueChange)
    {
        _speed += valueChange;
    }

    public void RemoveSpeed(float valueChange)
    {
        _speed -= valueChange;
    }
}