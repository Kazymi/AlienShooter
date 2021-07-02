using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour,IMovenment
{
    [SerializeField]  private Animator animator;
    
    private NavMeshAgent _navMeshAgent;
    private float _currentSpeed;
    private Transform _target;

    private const string _speed = "Speed";

    private void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
        animator.SetFloat(_speed, _navMeshAgent.velocity.magnitude);
    }
    
    public void Initialize(Transform playerTransform, float speed)
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentSpeed = speed;
        _navMeshAgent.speed = _currentSpeed;
        _target = playerTransform;
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
