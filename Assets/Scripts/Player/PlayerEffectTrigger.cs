using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class PlayerEffectTrigger : MonoBehaviour
{
    [SerializeField] private Buffer buffer;
    private void OnTriggerEnter(Collider other)
    {
        var i = other.GetComponent<EffectSpawn>();
        if (i != null)
        {
            buffer.TakeEffect(i.CurrentEffectSystem);
            i.Destroy();
        }
    }
}
