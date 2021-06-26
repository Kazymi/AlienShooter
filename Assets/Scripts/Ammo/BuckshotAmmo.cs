using System.Collections;
using UnityEngine;
public class BuckshotAmmo : MonoBehaviour,IAmmo
{
    [SerializeField] private int buckshotCount = 3;
    [SerializeField] private GameObject buckshotAmmo;
    [SerializeField] private float angle; 
    
    private AmmoConfiguration _ammoConfiguration;
    private int _enemyPassed;
    private Factory _factory;
    private Factory _buckshotFactory;
    private bool _initialized;

    private void OnDrawGizmosSelected()
    {
        var rayRange = 1.0f;
        var halfFOV = angle / 2.0f;
        var leftRayRotation = Quaternion.AngleAxis( -halfFOV, Vector3.up );
        var rightRayRotation = Quaternion.AngleAxis( halfFOV, Vector3.up );
        var leftRayDirection = leftRayRotation * transform.forward;
        var rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay( transform.position, leftRayDirection * rayRange );
        Gizmos.DrawRay( transform.position, rightRayDirection * rayRange );
    }

    public void Initialize(AmmoConfiguration ammoConfiguration,Factory parentFactory)
    {
        _ammoConfiguration = ammoConfiguration;
        _enemyPassed = 0;
        _factory = parentFactory;
        StartCoroutine(Destroy());
        if (_initialized == false)
        {
            _buckshotFactory = new Factory(buckshotAmmo,buckshotCount,transform);
            _initialized = true;
        }

        for (var i = 0; i < buckshotCount; i++)
        {
           var newBuckshot = _buckshotFactory.Create(transform.position);
           var rotate = angle / 2;
           newBuckshot.transform.parent = transform;
           var iAmmo = newBuckshot.GetComponent<IAmmo>();
           if (iAmmo != null)
           {
               iAmmo.Initialize(ammoConfiguration, _buckshotFactory);
           }
           newBuckshot.transform.localPosition = Vector3.zero;
           newBuckshot.transform.localRotation = Quaternion.identity;
           newBuckshot.transform.Rotate(0, Random.Range(-rotate,rotate), 0);
        }

    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_ammoConfiguration.LifeTime);
        _factory.Destroy(gameObject);
    }
}
