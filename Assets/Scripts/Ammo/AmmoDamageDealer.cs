using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class AmmoDamageDealer : MonoBehaviour
{
    private float _damage;
    public void Initialize(float damage)
    {
        _damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<Damageable>();
        if (damageable != null && !other.GetComponent<PlayerHealth>())
        {
            damageable.TakeDamage(_damage);
        }
    }
}
