using System.Collections;
using UnityEngine;

public class RoketAmmo : MonoBehaviour, IAmmo
{
    [SerializeField] private LayerMask ignoreLayer;
    [SerializeField] private Explosion explosion;
    [SerializeField] private GameObject roketGameObject;
    
    private AmmoConfiguration _ammoConfiguration;
    private Factory _factory;
    
    public void Initialize(AmmoConfiguration ammoConfiguration, Factory parentFactory)
    {
        _ammoConfiguration = ammoConfiguration;
        _factory = parentFactory;
        roketGameObject.SetActive(true);
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        transform.position += transform.forward * (_ammoConfiguration.SpeedAmmo * Time.deltaTime);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_ammoConfiguration.LifeTime);
        StartCoroutine(Explostion());
    }

    IEnumerator Explostion()
    {
        explosion.gameObject.SetActive(true);
        roketGameObject.SetActive(false);
        explosion.Initialize(_ammoConfiguration.Damage);
        yield return new WaitForSeconds(explosion.Lifetime+0.1f);
        _factory.Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == ignoreLayer)
        {
            StopAllCoroutines();
            StartCoroutine(Explostion());
        }
    }
}
