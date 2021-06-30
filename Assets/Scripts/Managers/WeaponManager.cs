using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponManager : MonoBehaviour, IInitializable
{
    [SerializeField] private List<WeaponConfiguration> weaponConfigurations;

    private Dictionary<string, Weapon> _weapons = new Dictionary<string, Weapon>();

    public List<WeaponConfiguration> WeaponConfigurations => weaponConfigurations;

    public List<Weapon> GetAllWeapon()
    {
        var weapons = new List<Weapon>();
        foreach (var weaponEntry in _weapons)
        {
            weapons.Add(weaponEntry.Value);
        }

        return weapons;
    }

    public WeaponConfiguration GetWeaponConfigurationByWeapon(Weapon weapon)
    {
        var weaponName = GetNameByWeapon(weapon);
        foreach (var weaponEntry in weaponConfigurations)
        {
            if (weaponEntry.Name == weaponName) return weaponEntry;
        }

        return null;
    }

    public string GetNameByWeapon(Weapon weapon)
    {
        foreach (var i in _weapons)
        {
            if (i.Value == weapon) return i.Key;
        }

        return null;
    }

    public Weapon GetWeaponByName(string name)
    {
        return _weapons[name];
    }

    private void NewWeapon(Weapon weapon, string nameWeapon)
    {
        var newGun = Instantiate(weapon, transform);
        newGun.gameObject.SetActive(false);
        _weapons.Add(nameWeapon, newGun);
    }

    public void Initialize()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        _weapons = new Dictionary<string, Weapon>();
        foreach (var i in weaponConfigurations)
        {
            NewWeapon(i.WeaponGameObject, i.Name);
        }
    }
}