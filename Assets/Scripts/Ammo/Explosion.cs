using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject effectExplosion;
    [SerializeField] private bool exploded;

    private void Update()
    {
        if (!exploded) return;
        exploded = false;
        Initialize(10);
    }

    private float _damage;

    public float Lifetime => lifeTime;

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
    
    public void Initialize(float damage)
    {
        _damage = damage;
        effectExplosion.SetActive(true);
        StartCoroutine(StartExplosion());
    }

    private IEnumerator StartExplosion()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var i in hitColliders)
        {
            var damageDealer = i.GetComponent<Damageable>();
            if (damageDealer != null && i.gameObject.activeInHierarchy)
            {
                damageDealer.TakeDamage(_damage);
            }
        }
        yield return new WaitForSeconds(lifeTime);
        effectExplosion.SetActive(false);
    }
    
    
}
