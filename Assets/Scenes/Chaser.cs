using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Chaser : MonoBehaviour
{
    public Transform Target;
    public Transform Spawn;
    public float UpdateSpeed = 0.1f;
    public bool isChasing = false;

    private NavMeshAgent myAgent;

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        StartCoroutine(FollowTarget());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;
        }
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        while (enabled)
        {
            if (isChasing)
            {
                myAgent.SetDestination(Target.position);
            }
            else
            {
                myAgent.SetDestination(Spawn.position);
            }

            yield return Wait;
        }
    }
}