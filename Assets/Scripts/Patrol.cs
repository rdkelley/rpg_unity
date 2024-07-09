using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    int current;
    NavMeshAgent agent;
    Animator animator; 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); 
        StartCoroutine(Patrolling());
    }

    private IEnumerator Patrolling()
    {
        while (enabled)
        {
            if (current == patrolPoints.Length)
                current = 0;
            agent.SetDestination(patrolPoints[current++].position);
            yield return new WaitUntil(() => agent.remainingDistance < 0.1f);
            yield return new WaitForSeconds(1);
        }
    }

    void Update()
    {
       animator.SetFloat("Speed", agent.speed);
    }
}
