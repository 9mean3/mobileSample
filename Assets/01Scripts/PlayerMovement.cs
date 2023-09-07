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
        playerInput.OnAttackKeyPress += Attack;
        playerInput.OnMovementKeyPress += Movement;
    }

    private void Start()
    {
    }

    private void Attack(Vector3 dir)
    {
        print("attack");
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, dir, distance, interactiveMask);
        foreach (RaycastHit hit in hits)
        {
            //hit
        }
    }

    private void Movement(Vector3 point)
    {
        print("Movement");
        Vector3 dir = point - transform.position;

    }
}
