using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] float radius;
    [SerializeField] float distance;
    [SerializeField] LayerMask interactiveMask;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        playerInput.OnAttackKeyPress += Attack;
        playerInput.OnMovementKeyPress += Movement;
    }

    private void Attack(Vector3 dir)
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, dir, distance, interactiveMask);
        foreach (RaycastHit hit in hits)
        {
            //hit
        }
    }

    private void Movement(Vector3 point)
    {
        throw new NotImplementedException();
    }
}
