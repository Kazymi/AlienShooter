using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradeSave
{
   [SerializeField] private List<WeaponCharacteristics> _weaponCharacteristicsList = new List<WeaponCharacteristics>();

    public List<WeaponCharacteristics> WeaponCharacteristicsList
    {
        get => _weaponCharacteristicsList;
        set => _weaponCharacteristicsList = value;
    }

    public void Initialize(List<WeaponConfiguration> weaponConfigurations)
    {
        _weaponCharacteristicsList = new List<WeaponCharacteristics>();
        foreach (var weaponConfiguration in weaponConfigurations)
        {
            var ammo = weaponConfiguration.AmmoConfiguration;
            var newWeaponCharacteristics = new WeaponCharacteristics(
                ammo.Damage,
                weaponConfiguration.FireRate,
                weaponConfiguration.TimeReloaded,
                ammo.SpeedAmmo,
                weaponConfiguration.MaxAmmo,
                weaponConfiguration.Name
            );
            _weaponCharacteristicsList.Add(newWeaponCharacteristics);
        }
    }

    public WeaponCharacteristics GetWeaponCharacteristics(string name)
    {
        foreach (var weaponCharacteristics in _weaponCharacteristicsList)
        {
            if (weaponCharacteristics.Name == name) return weaponCharacteristics;
        }
        return null;
    }
}