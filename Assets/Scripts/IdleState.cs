using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [Header("Properties")]
    [SerializeField] float elapsed;
    [SerializeField] float cooldown;

    [Header("States")]
    [SerializeField] ChaseState chaseState;
    [SerializeField] ReactState reactState;
    [SerializeField] PatrolState patrolState;

    private new void OnValidate()
    {
        base.OnValidate();
        chaseState = GetComponent<ChaseState>();
        reactState = GetComponent<ReactState>();
        patrolState = GetComponent<PatrolState>();
    }

    public override void Setup()
    {
        enemy.hp.onChange += () => Transition(reactState);
    }

    private void OnEnable()
    {

        elapsed = 0;
        animator.SetFloat("Speed", 0);
    }

    private void Update()
    {
        if (los.Detected())
        {
            Transition(chaseState);
            return;
        }

        elapsed += Time.deltaTime;

        if (elapsed > cooldown)
        {
            Transition(patrolState);
        }
    }
}