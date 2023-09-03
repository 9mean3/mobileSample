using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("참ㅈㅗ 변ㅅㅜㄷㅡㄹ ")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform _rootTrm;

    [Header("셋ㅌㅣㅇ 값ㄷㅡㄹ")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _gravityMultiplier = 1f;

    private CharacterController _characterController;
    public bool IsGround => _characterController.isGrounded;


    private Vector2 _inputDirection;
    private Vector3 _movementVelocity;
    public Vector3 MovementVelocity => _movementVelocity;
    private float _verticalVelocity;

    public bool ActiveMove { get; private set; } = true;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        playerInput.OnMovementKeyPress += SetMovement;
    }

    private void SetMovement(Vector2 movement)
    {
        _inputDirection = movement;
    }

    private void CalculatePlayerMovement()
    {
        _movementVelocity = (_rootTrm.forward * _inputDirection.y + _rootTrm.right * _inputDirection.x) * _moveSpeed * Time.fixedDeltaTime;
    }

    public void StopImmediately()
    {
        _movementVelocity = Vector3.zero;
    }

    public void SetMovement(Vector3 value)
    {
        _movementVelocity = new Vector3(value.x, 0, value.y);
        _verticalVelocity = value.y;
    }

    private void ApplyGravity()
    {
        if (IsGround && _verticalVelocity < 0)
        {
            _verticalVelocity = -1;
        }
        else
        {
            _verticalVelocity += _gravity * _gravityMultiplier * Time.fixedDeltaTime;
        }
        _movementVelocity.y = _verticalVelocity;
    }

    private void Move()
    {
        _characterController.Move(_movementVelocity);
    }

    private void FixedUpdate()
    {
        if (ActiveMove)
        {
            CalculatePlayerMovement();
        }
        ApplyGravity();
        Move();
    }
}