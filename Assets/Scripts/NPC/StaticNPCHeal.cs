using System;
using UnityEngine;

public class StaticNPCHeal : Damageable,IDeathInitialize,ITarget
{
    [SerializeField] private float Health;
    private void Start()
    {
        Initialize(Health,this);
    }

    public void DeadInitialize()
    {
        Destroy(gameObject);
    }
}
