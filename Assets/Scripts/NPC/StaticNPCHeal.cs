using System;
using UnityEngine;
using UnityEngine.Events;

public class StaticNPCHeal : Damageable,IDeathInitialize,ITarget
{
    [SerializeField] private UnityEvent unityEvent;
    [SerializeField] private float Health;
    private void Start()
    {
        Initialize(Health,this);
    }

    public void DeadInitialize()
    {
        unityEvent?.Invoke();
        Destroy(gameObject);
    }
}
