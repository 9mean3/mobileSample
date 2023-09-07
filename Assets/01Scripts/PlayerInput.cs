using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector3> OnAttackKeyPress;
    public event Action<Vector3> OnMovementKeyPress;

    void Update()
    {
        CheckAttackKey();
        CheckMovementKey();
    }

    void CheckAttackKey()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                OnAttackKeyPress.Invoke((hit.point - transform.position).normalized);
            }
        }
    }

    void CheckMovementKey()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                OnMovementKeyPress.Invoke(hit.point);
            }
        }
    }
}
