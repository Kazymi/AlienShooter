using System;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private float _currentSpeed;
    public void Initialize(Transform playerTransform, float speed)
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentSpeed = speed;
        _navMeshAgent.speed = _currentSpeed;
        StartCoroutine(MoveToPlayer(playerTransform));
    }

    private IEnumerator MoveToPlayer(Transform playerTransform)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            _navMeshAgent.SetDestination(playerTransform.position);
        }
    }

}
