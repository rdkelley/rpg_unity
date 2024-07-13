using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected UnityEngine.AI.NavMeshAgent agent;

    ////This script manages enemy line of sight
    [SerializeField] protected LineOfSight los;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Player player;
    public event Action<State> onEnter;

    public void OnValidate()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        los = GetComponent<LineOfSight>();
    }

    public abstract void Setup();

    protected void Transition(State state)
    {
        if (enabled)
        {
            onEnter?.Invoke(state);
        }
    }
}