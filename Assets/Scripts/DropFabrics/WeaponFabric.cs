using System.Collections.Generic;
using UnityEngine;

public class WeaponFabric
{
    private readonly Dictionary<WeaponConfiguration, Factory> _factories = new Dictionary<WeaponConfiguration, Factory>();

    public WeaponFabric(IEnumerable<WeaponSpawn> weaponSpawns,int countElement,Transform parent)
    {
        foreach (var i in weaponSpawns)
        {
            _factories.Add(i.WeaponConfiguration,new Factory(i.gameObject, countElement,parent));
        }
    }

    public Transform Spawn(WeaponConfiguration weaponConfiguration)
    {
        if (_factories.ContainsKey(weaponConfiguration))
        {
            var factory = _factories[weaponConfiguration];
            var newWeapon = factory.Create(Vector3.zero);
            newWeapon.GetComponent<WeaponSpawn>().Initialize(factory);
            return newWeapon.transform;
        }
        else
        {
            Debug.LogError($@"Effect {weaponConfiguration} not found");
            return null;
        }
    }
}