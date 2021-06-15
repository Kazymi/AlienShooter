using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Ak47 : WeaponControlFire
{
    private InputHandler _inputHandler;
    public override void Fire()
    {
        if(_lockFire || _reloaded) return;
        _ammo--;
        if (_ammo == 0) StartCoroutine(Reloaded());
        GameObject ammo = _factory.Create(positionSpawnAmmo.position);
        ammo.GetComponent<IAmmo>().Initialize(_weaponConfiguration.AmmoConfiguration,_factory);
        ammo.transform.position = positionSpawnAmmo.position;
        ammo.transform.rotation = positionSpawnAmmo.rotation;
        StartCoroutine(FireRateTimer());
    }
    private void Update()
    {
        if(_inputHandler.Fire) Fire();
    }

    [Inject]
    private void Construct(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }
    public override void InitializeWeapon(WeaponConfiguration weaponConfiguration)
    {
        base.InitializeWeapon(weaponConfiguration);
        _ammo = _weaponConfiguration.MaxAmmo;
    }
}
