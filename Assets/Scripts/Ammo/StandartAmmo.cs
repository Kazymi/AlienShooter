using System.Collections;
using UnityEngine;

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
}
