using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float lifeTime;

    private float _damage;

    public float Lifetime => lifeTime;

    public void Initialize(float damage)
    {
        _damage = damage;
        StartCoroutine(StartExplosion());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }

    IEnumerator StartExplosion()
    {
        Collider[] hitColliders = new Collider[25];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, radius, hitColliders);
        for (int i = 0; i < numColliders; i++)
        {
            var damageDealer = hitColliders[i].GetComponent<Damageable>();
            if (damageDealer != null)
            {
                damageDealer.TakeDamage(_damage);
            }
        }

        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
    
    
}
