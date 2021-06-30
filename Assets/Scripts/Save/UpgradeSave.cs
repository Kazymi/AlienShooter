using System.Collections.Generic;

public class UpgradeSave
{
    private SaveData _saveData;

    public UpgradeSave(SaveData saveData)
    {
        _saveData = saveData;
    }

    public void Initialize(List<WeaponConfiguration> weaponConfigurations)
    {
        _saveData.WeaponCharacteristicsList = new List<WeaponCharacteristics>();
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
            _saveData.WeaponCharacteristicsList.Add(newWeaponCharacteristics);
        }
    }

    public WeaponCharacteristics GetWeaponCharacteristics(string name)
    {
        foreach (var weaponCharacteristics in _saveData.WeaponCharacteristicsList)
        {
            if (weaponCharacteristics.Name == name) return weaponCharacteristics;
        }
        return null;
    }
}