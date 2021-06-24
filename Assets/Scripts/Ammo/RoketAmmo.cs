using System.Collections;
using UnityEngine;

public class RoketAmmo : MonoBehaviour, IAmmo
{
    [SerializeField] private Explosion explosion;
    [SerializeField] private GameObject roketGameObject;

    private bool exploded;
    private AmmoConfiguration _ammoConfiguration;
    private Factory _factory;

    private void Update()
    {
        transform.position += transform.forward * (_ammoConfiguration.SpeedAmmo * Time.deltaTime);
    }

    public void Initialize(AmmoConfiguration ammoConfiguration, Factory parentFactory)
    {
        exploded = false;
        _ammoConfiguration = ammoConfiguration;
        _factory = parentFactory;
        roketGameObject.SetActive(true);
        StartCoroutine(Destroy());
    }
    
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_ammoConfiguration.LifeTime);
        StartCoroutine(Explostion());
    }

    private IEnumerator Explostion()
    {
        roketGameObject.SetActive(false);
        explosion.Initialize(_ammoConfiguration.Damage);
        yield return new WaitForSeconds(explosion.Lifetime+0.1f);
        _factory.Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(exploded) return;
        exploded = true;
        StopAllCoroutines();
        StartCoroutine(Explostion());
    }
}
