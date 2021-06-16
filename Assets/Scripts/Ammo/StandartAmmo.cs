using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]

public class StandartAmmo : MonoBehaviour,IAmmo
{
    private AmmoConfiguration _ammoConfiguration;
    private Factory _factory;
    
    public void Initialize(AmmoConfiguration ammoConfiguration, Factory parentFactory)
    {
        _ammoConfiguration = ammoConfiguration;
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
        var i = (other.GetComponent<IDamageable>());
        if (i != null)
        {
            i.TakeDamage(_ammoConfiguration.Damage);
            _factory.Destroy(gameObject);
        }
        
    }
}
