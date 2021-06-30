using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponManager : MonoInstaller, IInitializable
{
    [SerializeField] private List<WeaponConfiguration> weaponConfigurations;

    private Dictionary<string, Weapon> _weapons = new Dictionary<string, Weapon>();

    public override void InstallBindings()
    {
        Container.Bind(typeof(WeaponManager), typeof(IInitializable)).FromInstance(this).AsSingle();
        foreach (var i in _weapons)
        {
            Destroy(i.Value.gameObject);
        }

        _weapons = new Dictionary<string, Weapon>();
        foreach (var i in weaponConfigurations)
        {
            NewWeapon(i.WeaponGameObject, i.Name);
        }
    }

    public List<Weapon> GetAllWeapon()
    {
        var i = new List<Weapon>();
        foreach (var VARIABLE in _weapons)
        {
            i.Add(VARIABLE.Value);
        }

        return i;
    }

    public WeaponConfiguration GetWeaponConfigurationByWeapon(Weapon weapon)
    {
        var name = GetNameByWeapon(weapon);
        foreach (var i in weaponConfigurations)
        {
            if (i.Name == name) return i;
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