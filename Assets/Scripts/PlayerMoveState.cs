using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OnAim()
    {
        Transition(aimState);
    }
}
