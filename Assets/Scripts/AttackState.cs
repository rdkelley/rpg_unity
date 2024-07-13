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

    private new void OnValidate()
    {
        base.OnValidate();
        chaseState = GetComponent<ChaseState>();
        reactState = GetComponent<ReactState>();
    }

    public override void Setup()
    {
        enemy.hp.onChange += () => Transition(reactState);
    }

    [SerializeField] bool attacking;
    private void Update()
    {
        var direction = player.transform.position - transform.position;
        if (canTransition && direction.sqrMagnitude > distanceThreshold)
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

    }
}