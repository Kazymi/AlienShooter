using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]

public class ArmorPiercingAmmo : MonoBehaviour,IAmmo
{
    [SerializeField] private int maxEnemy = 3;
    [SerializeField][Range(0,100)] private int damageReduction = 25;
    [SerializeField] private LayerMask ignoreLayer;
    
    private int _enemyPassed;
    private float _currentDamage;
    private AmmoConfiguration _ammoConfiguration;
    private Factory _factory;

    public void Initialize(AmmoConfiguration ammoConfiguration, Factory parentFactory)
    {
        _ammoConfiguration = ammoConfiguration;
        _currentDamage = ammoConfiguration.Damage;
        _enemyPassed = 0;
        _factory = parentFactory;
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        transform.position += transform.forward * (_ammoConfiguration.SpeedAmmo * Time.deltaTime);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_ammoConfiguration.LifeTime);
        _factory.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var i = (other.GetComponent<Damageable>());
        if (i != null)
        {
            _enemyPassed++;
            _currentDamage -= _currentDamage * (damageReduction / 100);  
            i.TakeDamage(_ammoConfiguration.Damage);
        }

        if (other.gameObject.layer == ignoreLayer || _enemyPassed==maxEnemy)
        {
            StopAllCoroutines();
            _factory.Destroy(gameObject);
        }
    }
}
