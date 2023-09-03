using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnAttackKeyPress;
    public event Action<Vector3> OnMovementKeyPress;

    [SerializeField] LayerMask NotPlayerLM;

    void Update()
    {
        CheckAttackKey();
        CheckMovementKey();
    }

    void CheckAttackKey()
    {
        if(Input.GetMouseButtonUp(0))
            OnAttackKeyPress.Invoke();
    }

    void CheckMovementKey()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, NotPlayerLM))
            {
                OnMovementKeyPress.Invoke(hitInfo.point);
            }
        }
    }
}
