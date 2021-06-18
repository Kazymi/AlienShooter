using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour,ISpeed
{
    private NavMeshAgent _navMeshAgent;
    private float _currentSpeed;
    public Dictionary<TypeBuff, float> ActiveBuffs { get; set; }

    public void Initialize(Transform playerTransform, float speed)
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentSpeed = speed;
        _navMeshAgent.speed = _currentSpeed;
        StartCoroutine(MoveToPlayer(playerTransform));
    }
    
    public void AddBuff(TypeBuff buff, float valueSpeed)
    {
        if (!ActiveBuffs.ContainsKey(buff))
        {
            ActiveBuffs.Add(buff,valueSpeed);
            _currentSpeed += valueSpeed;
        }
    }

    public void DeactivateBuff(TypeBuff buff)
    {
        if (ActiveBuffs.ContainsKey(buff))
        {
            _currentSpeed -= ActiveBuffs[buff];
            ActiveBuffs.Remove(buff);
        }
    }
    private IEnumerator MoveToPlayer(Transform playerTransform)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            _navMeshAgent.speed = _currentSpeed;
            _navMeshAgent.SetDestination(playerTransform.position);
        }
    }
}
