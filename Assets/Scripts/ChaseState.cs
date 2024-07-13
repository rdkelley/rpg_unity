using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [Header("Properties")]
    [SerializeField] float maxDistance;
    [SerializeField] float distanceThreshold;
    [SerializeField] Transform eyes;

    [Header("States")]
    [SerializeField] AttackState attackState;
    [SerializeField] ReactState reactState;
    [SerializeField] IdleState idleState;
    private new void OnValidate()
    {
        base.OnValidate();
        attackState = GetComponent<AttackState>();
        reactState = GetComponent<ReactState>();
        idleState = GetComponent<IdleState>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }

    public override void Setup()
    {
        Debug.Log("Chase state enabled");
        enemy.hp.onChange += () => Transition(reactState);
    }

    int miss;
    private IEnumerator Check()
    {
        while (true)
        {
            RaycastHit hit;
            if (Physics.Raycast(eyes.position, player.transform.position - transform.position, out hit, maxDistance))
            {
                if (hit.distance < distanceThreshold)
                {
                    Debug.Log("Dis:" + hit.distance);
                    Transition(attackState);
                    break;
                }
                var p = hit.transform.GetComponent<Player>();
                //if (!p)
                //{
                //    miss++;
                //    if (miss > 5)
                //    {
                //        Transition(idleState);
                //        break;
                //    }
                //}
                //else
                //{
                //    miss = 0;
                //}
            }
            if (agent.enabled)
                agent.SetDestination(player.transform.position);
            yield return new WaitForSeconds(.5f);
        }
    }

    Coroutine checking;
    private void OnEnable()
    {
        miss = 0;
        agent.enabled = true;
        agent.speed = 3;
        if (checking != null)
            StopCoroutine(checking);
        checking = StartCoroutine(Check());
    }

    private void OnDisable()
    {
        if (checking != null)
            StopCoroutine(checking);
        animator.SetFloat("Speed", 0);
    }
}