using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    [SerializeField] List<PlayerState> states;

    //Set this in the Inspector window
    [SerializeField] PlayerState current;

    private void OnValidate()
    {
        states = GetComponentsInChildren<PlayerState>().ToList();
    }

    private void Start()
    {
        foreach (var state in states)
        {
            state.onEnter += ChangeState;
            state.Setup();
        }

        Debug.Log("Setting current state to " + current);
        current.enabled = true;
    }

    void ChangeState(PlayerState other)
    {
        Debug.Log("Changing state from " + current + " to " + other);

        current.enabled = false;
        current = other;
        current.enabled = true;
    }
}