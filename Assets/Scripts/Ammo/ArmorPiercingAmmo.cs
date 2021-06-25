using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]

public class ArmorPiercingAmmo : MonoBehaviour,IAmmo
{
    [SerializeField] private int maxEnemyPenetration = 3;
    [SerializeField][Range(0,100)] private int damageReduction = 25;

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
        else
        {
            StopAllCoroutines();
            _factory.Destroy(gameObject);
        }

        if (_enemyPassed != maxEnemyPenetration) return;
        StopAllCoroutines();
        _factory.Destroy(gameObject);
    }
}
