using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactState : State
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
        Debug.Log("React state enabled");
    }

    private void Update()
    {

    }
}