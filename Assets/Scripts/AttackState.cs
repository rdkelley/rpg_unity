using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [Header("Fields")]
    [SerializeField] float distanceThreshold;
    [SerializeField] float cooldown;
    [SerializeField] bool playerInSights;
    [SerializeField] Transform eyes;
    [SerializeField] Weapon weapon;

    [Header("States")]
    [SerializeField] ChaseState chaseState;
    [SerializeField] ReactState reactState;
    [SerializeField] SleepState sleepState;

    private new void OnValidate()
    {
        base.OnValidate();
        chaseState = GetComponent<ChaseState>();
        reactState = GetComponent<ReactState>();
        sleepState = GetComponent<SleepState>();
    }

    public override void Setup()
    {
        enemy.hp.onChange += () => Transition(reactState);
        enemy.SleepInit += () => Transition(sleepState);
    }

    [SerializeField] bool attacking;
    private void Update()
    {
        var direction = player.transform.position - transform.position;
        if (direction.sqrMagnitude > distanceThreshold * distanceThreshold)
        {
            Transition(chaseState);
            return;
        }
        if (attacking)
            return;

        attacking = true;
        weapon = GetComponentInChildren<Weapon>();
        transform.forward = direction;
        agent.enabled = false;
        canTransition = false;
        animator.SetTrigger("Attack");
    }

    private void OnEnable()
    {
        attacking = false;
    }

    private void OnDisable()
    {
        attacking = false;
    }

    public void Draw()
    {
        weapon.Activate();
    }

    bool canTransition;
    public void Sheathe()
    {
        weapon.Deactivate();
        canTransition = true;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        attacking = false;
        canTransition = false;
        Transition(chaseState);
    }
}