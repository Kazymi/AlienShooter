using System.Collections;
using ScriptableObjects.Effects;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class FieldOfFire : MonoBehaviour
{
    [SerializeField] private float lifetimer;
    [SerializeField] private FireDamageConfiguration _fireDamage;
    [SerializeField] private GameObject _fireEffect;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _fireEffect.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        var i = other.GetComponent<Buffer>();
        if (i != null)
        {
            i.TakeEffect(_fireDamage);
        }
    }

    public void Initialize()
    {
        _collider.enabled = true;
        _fireEffect.SetActive(true);
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(lifetimer);
        _collider.enabled = false;
        _fireEffect.SetActive(false);
    }
}
