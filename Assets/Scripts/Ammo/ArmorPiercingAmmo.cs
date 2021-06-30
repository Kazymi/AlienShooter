using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class ArmorPiercingAmmo : MonoBehaviour, IAmmo
{
    [SerializeField] private int maxPenetrationInEnemy = 3;
    [SerializeField] [Range(0, 50)] private int damageReduction = 25;

    private int _enemyPassed;
    private float _currentDamage;
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
            _enemyPassed++;
            _currentDamage -= _currentDamage * (damageReduction / 100);
            i.TakeDamage(_ammoConfiguration.Damage);
        }
        else
        {
            StopAllCoroutines();
            _factory.Destroy(gameObject);
        }

        if (_enemyPassed != maxPenetrationInEnemy) return;
        StopAllCoroutines();
        _factory.Destroy(gameObject);
    }

    public void Initialize(WeaponCharacteristics ammoConfiguration,float lifeTime, Factory parentFactory)
    {
        _ammoConfiguration = ammoConfiguration;
        _currentDamage = ammoConfiguration.Damage;
        _enemyPassed = 0;
        _factory = parentFactory;
        StartCoroutine(Destroy(lifeTime));
    }

    private IEnumerator Destroy(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        _factory.Destroy(gameObject);
    }
}