using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class SuperPenetrationAmmo : MonoBehaviour, IAmmo
{
    private WeaponCharacteristics _ammoConfiguration;
    private Factory _factory;

    private void Update()
    {
        transform.position += transform.forward * (_ammoConfiguration.SpeedAmmo * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var i = (other.GetComponent<Damageable>());
        if (i != null)
        {
            i.TakeDamage(_ammoConfiguration.Damage);
            return;
        }
        StopAllCoroutines();
        _factory.Destroy(gameObject);
    }

    public void Initialize(WeaponCharacteristics ammoConfiguration,float lifetime, Factory parentFactory)
    {
        _ammoConfiguration = ammoConfiguration;
        _factory = parentFactory;
        StartCoroutine(Destroy(lifetime));
    }

    private IEnumerator Destroy(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        _factory.Destroy(gameObject);
    }
}