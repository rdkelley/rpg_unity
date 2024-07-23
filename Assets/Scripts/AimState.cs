using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : PlayerState
{
    private new void OnValidate()
    {
        base.OnValidate();
    }

    public override void Setup()
    {
    }

    private void OnEnable()
    {
        Debug.Log("Aim state enabled");

        animator.SetBool("Aim", true);
    }
}
