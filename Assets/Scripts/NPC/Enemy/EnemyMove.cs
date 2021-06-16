using System;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public void Initialize(Transform playerTransform,float speed)
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = speed;
        _navMeshAgent.SetDestination(playerTransform.position);
    }
}
