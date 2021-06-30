using System;
using UnityEngine;

[Serializable]
public class WeaponCharacteristics
{
    [SerializeField] private string _name;
    [SerializeField] private float _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _speedReloaded;
    [SerializeField] private float _speedAmmo;
    [SerializeField] private int _countAmmo;

    public string Name => _name;
    public float Damage => _damage;
    public float FireRate => _fireRate;
    public float SpeedReloaded => _speedReloaded;
    public float SpeedAmmo => _speedAmmo;
    public float CountAmmo => _countAmmo;

    public WeaponCharacteristics(float damage, float fireRate, float speedReloaded, float speedAmmo, int countAmmo, string name)
    {
        _name = name;
        _damage = damage;
        _fireRate = fireRate;
        _speedReloaded = speedReloaded;
        _speedAmmo = speedAmmo;
        _countAmmo = countAmmo;
    }
}