using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [Header("Properties")]
    [SerializeField] int current;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float minDistance;

    [Header("Transitions")]
    [SerializeField] ChaseState chaseState;
    [SerializeField] ReactState reactState;
    [SerializeField] IdleState idleState;

    int pointsReached;

    private new void OnValidate()
    {
        base.OnValidate();
        chaseState = GetComponent<ChaseState>();
        reactState = GetComponent<ReactState>();
        idleState = GetComponent<IdleState>();

        pointsReached = 0;
    }

    public override void Setup()
    {
        enemy.hp.onChange += () => Transition(reactState);
    }

    private void OnEnable()
    {
        agent.SetDestination(waypoints[current++].position);

        if (current == waypoints.Count)
            current = 0;
    }

    private void OnDisable()
    {
        agent.ResetPath();
    }

    private void Update()
    {
        //if (pointsReached == 2)
        //{
        //    Transition(chaseState);
        //    return;
        //}

        if (los.Detected())
        {
            Transition(chaseState);
            return;
        }

        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

        if (agent.remainingDistance < minDistance)
        {
            pointsReached++;
            Transition(idleState);
        }
    }
}