using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class RocketAmmo : MonoBehaviour, IAmmo
{
    [SerializeField] private Explosion explosion;
    [SerializeField] private GameObject rocketGameObject;

    private bool _exploded;
    private AmmoConfiguration _ammoConfiguration;
    private Factory _factory;

    private void Update()
    {
        transform.position += transform.forward * (_ammoConfiguration.SpeedAmmo * Time.deltaTime);
    }

    public void Initialize(AmmoConfiguration ammoConfiguration, Factory parentFactory)
    {
        _exploded = false;
        _ammoConfiguration = ammoConfiguration;
        _factory = parentFactory;
        rocketGameObject.SetActive(true);
        StartCoroutine(Destroy());
    }
    
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_ammoConfiguration.LifeTime);
        StartCoroutine(Explostion());
    }

    private IEnumerator Explostion()
    {
        rocketGameObject.SetActive(false);
        explosion.Initialize(_ammoConfiguration.Damage);
        yield return new WaitForSeconds(explosion.Lifetime+0.1f);
        _factory.Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(_exploded) return;
        _exploded = true;
        StopAllCoroutines();
        StartCoroutine(Explostion());
    }
}
