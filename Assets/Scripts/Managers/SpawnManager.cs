using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int countElement;
    [SerializeField] private List<EffectSpawn> effectSystems = new List<EffectSpawn>();
    [SerializeField] private List<WeaponSpawn> weaponSpawns = new List<WeaponSpawn>();

    private EffectFabric _effectFabric;
    private WeaponFabric _weaponFabric;

    private void Start()
    {
        _effectFabric = new EffectFabric(effectSystems, countElement);
        _weaponFabric = new WeaponFabric(weaponSpawns, countElement);
    }

    public Transform GetEffect(EffectSystem effectSystem)
    {
        return _effectFabric.Spawn(effectSystem);
    }

    public Transform GetWeapon(WeaponConfiguration weaponConfiguration)
    {
        return _weaponFabric.Spawn(weaponConfiguration);
    }
}
