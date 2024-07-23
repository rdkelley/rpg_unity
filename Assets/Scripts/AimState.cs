using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class AimState : PlayerState
{
    [SerializeField] PlayerMoveState moveState;

    private new void OnValidate()
    {
        base.OnValidate();

        moveState = GetComponent<PlayerMoveState>();
        controller = GetComponent<ThirdPersonController>();
    }

    public override void Setup()
    {
    }

    private void OnEnable()
    {
        Debug.Log("Aim state enabled");

        animator.SetBool("Aim", true);
    }

    private void Update()
    {
        transform.forward = camera.transform.forward;
    }
}
