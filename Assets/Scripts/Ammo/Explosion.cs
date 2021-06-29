using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float timeExplosion;
    [SerializeField] private GameObject effectExplosion;

    private float _damage;

    public float Lifetime => timeExplosion;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Initialize(float damage)
    {
        _damage = damage;
        effectExplosion.SetActive(true);
        StartCoroutine(StartExplosion());
    }

    private IEnumerator StartExplosion()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var i in hitColliders)
        {
            var damageDealer = i.GetComponent<Damageable>();
            if (damageDealer != null && i.gameObject.activeInHierarchy)
            {
                damageDealer.TakeDamage(_damage);
            }
        }
        yield return new WaitForSeconds(timeExplosion);
        effectExplosion.SetActive(false);
    }
}