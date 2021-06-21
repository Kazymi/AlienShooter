using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour,IChangeSpeed
{
    private NavMeshAgent _navMeshAgent;
    private float _currentSpeed;
    private Transform _target;
    public void Initialize(Transform playerTransform, float speed)
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentSpeed = speed;
        _navMeshAgent.speed = _currentSpeed;
        _target = playerTransform;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
    }

    public void AddSpeed(float valueChange)
    {
        _currentSpeed += valueChange;
        ChangeSpeed();
    }
    public void RemoveSpeed(float valueChange)
    {
        _currentSpeed -= valueChange;
        ChangeSpeed();
    }

    private void ChangeSpeed()
    {
        float currentSpeed = _currentSpeed > 0 ? _currentSpeed : 0;
        _navMeshAgent.speed = currentSpeed;
    }
}
