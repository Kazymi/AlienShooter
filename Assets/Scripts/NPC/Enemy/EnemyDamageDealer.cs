using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class EnemyDamageDealer : MonoBehaviour
{
    private float _damage;

    public void Initialize(float damage)
    {
        _damage = damage;
    }
    private void OnTriggerStay(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(_damage);
        }
    }
}
