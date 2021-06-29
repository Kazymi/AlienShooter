using System.Collections;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform positionSpawnAmmo;
    
    private Factory _factory;
    private WeaponConfiguration _weaponConfiguration;
    private AmmoConfiguration _currentWeaponConfiguration;
    private bool _initialized;
    private bool _lockFire;
    private bool _reloaded;
    private SignalBus _signalBus;
    private int _ammo;

    public void Initialize(WeaponConfiguration gunConfiguration,Transform parentAmmo, SignalBus signalBus)
    {
        _signalBus = signalBus;
        _signalBus.Fire(new AmmoChangedSignal(_ammo));
        transform.localPosition = Vector3.zero;
        _reloaded = false;
        _lockFire = false;
        InitializeWeapon(gunConfiguration);
        if(_initialized) return;
        _initialized = true;
        InitializeFactory(parentAmmo);
        _currentWeaponConfiguration = gunConfiguration.AmmoConfiguration;
        _ammo = _weaponConfiguration.MaxAmmo;
        _signalBus.Fire(new AmmoChangedSignal(_ammo));
    }
    
    public void Fire()
    {
        if(_lockFire || _reloaded) return;
        _ammo--;
        if (_ammo <= 0)
        { 
            StartCoroutine(StartReloaded());
            return;
        }
        _signalBus.Fire(new AmmoChangedSignal(_ammo));
        var ammo = _factory.Create(positionSpawnAmmo.position);
        ammo.GetComponent<IAmmo>().Initialize(_currentWeaponConfiguration,_factory);
        ammo.transform.position = positionSpawnAmmo.position;
        ammo.transform.rotation = positionSpawnAmmo.rotation;
        StartCoroutine(FireRateTimer());
    }
    private IEnumerator StartReloaded()
    {
        _reloaded = true;
        yield return new WaitForSeconds(_weaponConfiguration.TimeReloaded);
        _ammo = _weaponConfiguration.MaxAmmo;
        _signalBus.Fire(new AmmoChangedSignal(_ammo));
        _reloaded = false;
    }
    
    private void InitializeFactory(Transform parentAmmo)
    {
        _factory = new Factory(_weaponConfiguration.AmmoConfiguration.AmmoGameObject,30,parentAmmo);
    }

    private void InitializeWeapon(WeaponConfiguration weaponConfiguration)
    {
        _weaponConfiguration = weaponConfiguration;
    }

    private IEnumerator FireRateTimer()
    {
        _lockFire = true;
        yield return new WaitForSeconds(_weaponConfiguration.FireRate);
        _lockFire = false;
    }
}
