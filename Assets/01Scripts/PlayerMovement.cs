using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] float movementSpeed;
    [SerializeField] float radius;
    [SerializeField] float attGotoFwd;
    [SerializeField] float distance;
    [SerializeField] LayerMask interactiveMask;

    CharacterController cc;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnAttackKeyPress += Attack;
        playerInput.OnMovementKeyPress += Movement;

        cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
    }

    private void Attack(Vector3 dir)
    {
        print("attack");
        RaycastHit[] hits = Physics.SphereCastAll(transform.position+ transform.forward * attGotoFwd, radius, dir, distance, interactiveMask);
        foreach (RaycastHit hit in hits)
        {
            //hit
            print($"hit: {hit.transform.name}");
            hit.transform.GetComponent<Enemy>().GetDamage(3);
        }
    }

    private void Movement(Vector3 point)
    {
        print("Movement");
        Vector3 dir = point - transform.position;
        dir.Normalize();
        dir.y = 0;
        cc.Move(dir * movementSpeed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(dir) ;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + transform.forward * attGotoFwd, radius);
    }
}
