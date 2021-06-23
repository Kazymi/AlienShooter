using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider))]
public class WeaponSpawn : MonoBehaviour
{
    [SerializeField] private WeaponConfiguration weaponConfiguration;
    private Factory _factory;

    public void Initialize(Factory factory)
    {
        _factory = factory;
    }
    public WeaponConfiguration WeaponConfiguration => weaponConfiguration;

    public void Destroy()
    {
        _factory.Destroy(gameObject);
    }
}