using System.Collections.Generic;
using UnityEngine;

public class UpgradeSave
{
    private SaveData _saveData;

    public UpgradeSave(SaveData saveData)
    {
        _saveData = saveData;
    }
    public WeaponCharacteristics GetWeaponCharacteristics(string name)
    {
        foreach (var i in _saveData.WeaponCharacteristicsList)
        {
            if (i.Name == name) return i;
        }
        return null;
    }

    public void Initialize(List<WeaponConfiguration> weaponConfigurations)
    {
        _saveData.WeaponCharacteristicsList = new List<WeaponCharacteristics>();
        foreach (var i in weaponConfigurations)
        {
            var ammo = i.AmmoConfiguration;
            var newWeaponCharacteristics = new WeaponCharacteristics(
                ammo.Damage,
                i.FireRate,
                i.TimeReloaded,
                ammo.SpeedAmmo,
                i.MaxAmmo,
                i.Name
            );
            _saveData.WeaponCharacteristicsList.Add(newWeaponCharacteristics);
        }
    }
}