using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] private float timeToDamage;
    
    private bool _damageLock;
    private float _damage;

    public void Initialize(float damage)
    {
        _damage = damage;
        _damageLock = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(_damageLock) return;
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(_damage);
            StartCoroutine(DamageLock());
        }
    }

    private IEnumerator DamageLock()
    {
        _damageLock = true;
        yield return new WaitForSeconds(timeToDamage);
        _damageLock = false;
    }
}
