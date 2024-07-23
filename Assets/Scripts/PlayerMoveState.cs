using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerState
{
    [Header("Properties")]
    [SerializeField] int current;

    [Header("Transitions")]
    [SerializeField] AimState aimState;

    private new void OnValidate()
    {
        base.OnValidate();
        aimState = GetComponent<AimState>();
    }

    public override void Setup()
    {

    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Transition(aimState);
        }
    }
}
