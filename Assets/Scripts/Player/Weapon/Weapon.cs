using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform positionSpawnAmmo;

    private Factory _factory;
    private WeaponConfiguration _weaponConfiguration;
    private bool _initialized;
    private bool _lockFire;
    private bool _reloaded;
    private SignalBus _signalBus;
    private int _ammo;
    private int _maxAmmo;
    private WeaponCharacteristics _weaponCharacteristics;

    public void Initialize(WeaponConfiguration weaponConfiguration, Transform parentAmmo, SignalBus signalBus, WeaponCharacteristics weaponCharacteristics)
    {
        _weaponCharacteristics = weaponCharacteristics;
        _signalBus = signalBus;
        _signalBus.Fire(new AmmoChangedSignal(_ammo));
        transform.localPosition = Vector3.zero;
        _reloaded = false;
        _lockFire = false;
        InitializeWeapon(weaponConfiguration);
        if (_initialized) return;
        _initialized = true;
        InitializeFactory(parentAmmo);
        _maxAmmo = Convert.ToInt32(weaponCharacteristics.CountAmmo);
        _ammo = _maxAmmo;
        _signalBus.Fire(new AmmoChangedSignal(_ammo));
    }

    public void Fire()
    {
        if (_lockFire || _reloaded) return;
        _ammo--;
        if (_ammo <= 0)
        {
            StartCoroutine(StartReloaded());
            return;
        }
        _signalBus.Fire(new AmmoChangedSignal(_ammo));
        var ammo = _factory.Create(positionSpawnAmmo.position);
        ammo.GetComponent<IAmmo>().Initialize(_weaponCharacteristics, _weaponConfiguration.AmmoConfiguration.LifeTime, _factory);
        ammo.transform.position = positionSpawnAmmo.position;
        ammo.transform.rotation = positionSpawnAmmo.rotation;
        StartCoroutine(FireRateTimer());
    }

    private IEnumerator StartReloaded()
    {
        _reloaded = true;
        yield return new WaitForSeconds(_weaponConfiguration.TimeReloaded);
        _ammo = _maxAmmo;
        _signalBus.Fire(new AmmoChangedSignal(_ammo));
        _reloaded = false;
    }

    private void InitializeFactory(Transform parentAmmo)
    {
        _factory = new Factory(_weaponConfiguration.AmmoConfiguration.AmmoGameObject, 30, parentAmmo);
    }

    private void InitializeWeapon(WeaponConfiguration weaponConfiguration)
    {
        _weaponConfiguration = weaponConfiguration;
    }

    private IEnumerator FireRateTimer()
    {
        _lockFire = true;
        yield return new WaitForSeconds(_weaponCharacteristics.FireRate);
        _lockFire = false;
    }
}