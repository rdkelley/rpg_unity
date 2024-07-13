using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class FSM : MonoBehaviour
{
    [SerializeField] List<State> states;

    //Set this in the Inspector window
    [SerializeField] State current;

    private void OnValidate()
    {
        states = GetComponentsInChildren<State>().ToList();

    }
    private void Start()
    {
        foreach (var state in states)
        {
            state.onEnter += ChangeState;
            state.Setup();
        }
        current.enabled = true;
    }

    void ChangeState(State other)
    {
        current.enabled = false;
        current = other;
        current.enabled = true;
    }
}