using System.Collections;
using UnityEngine;

public class Ak47 : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform positionSpawnAmmo;
    
    private Factory _factory;
    private WeaponConfiguration _weaponConfiguration;
    private bool _lockFire;
    private bool _reloaded;
    private float _ammo;
    
    public Factory Factory { get => _factory; set => _factory = value; }
    
    public void Fire()
    {
        if(_lockFire || _reloaded) return;
        _ammo--;
        if (_ammo == 0) StartCoroutine(Reloaded());
        _factory.Create(positionSpawnAmmo.position);
        StartCoroutine(FireRateTimer());
    }

    public IEnumerator Reloaded()
    {
        _reloaded = true;
        yield return new WaitForSeconds(_weaponConfiguration.TimeReloaded);
        _ammo = _weaponConfiguration.MaxAmmo;
        _reloaded = false;
    }

    public void InitializeFactory()
    {
        _factory = new Factory(_weaponConfiguration.AmmoConfiguration.AmmoGameObject,30);
    }

    public void InitializeWeapon(WeaponConfiguration weaponConfiguration)
    {
        _weaponConfiguration = weaponConfiguration;
    }

    IEnumerator FireRateTimer()
    {
        _lockFire = true;
        yield return new WaitForSeconds(_weaponConfiguration.FireRate);
        _lockFire = false;
    }
}
