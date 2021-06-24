using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]

public class StandartAmmo : MonoBehaviour,IAmmo
{
    private AmmoConfiguration _ammoConfiguration;
    private Factory _factory;

    private void Update()
    {
        transform.position += transform.forward * (_ammoConfiguration.SpeedAmmo * Time.deltaTime);
    }

    public void Initialize(AmmoConfiguration ammoConfiguration, Factory parentFactory)
    {
        _ammoConfiguration = ammoConfiguration;
        _factory = parentFactory;
        StartCoroutine(Destroy());
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
            i.TakeDamage(_ammoConfiguration.Damage);
        }
        StopAllCoroutines();
        _factory.Destroy(gameObject);
    }
}
