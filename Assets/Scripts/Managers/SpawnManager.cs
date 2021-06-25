using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int countElement;
    [SerializeField] private List<EffectSpawn> effectSystems = new List<EffectSpawn>();
    [SerializeField] private List<WeaponSpawn> weaponSpawns = new List<WeaponSpawn>();
    [SerializeField] private List<OtherEffect> otherEffects = new List<OtherEffect>();

    private EffectFabric _effectFabric;
    private WeaponFabric _weaponFabric;
    private OtherEffectFabric _otherEffectFabric;

    private void Start()
    {
        _otherEffectFabric = new OtherEffectFabric(otherEffects, countElement);
        _effectFabric = new EffectFabric(effectSystems, countElement);
        _weaponFabric = new WeaponFabric(weaponSpawns, countElement);
    }

    public Transform Spawn(EffectSystem effectSystem)
    {
        return _effectFabric.Spawn(effectSystem);
    }

    public Transform Spawn(WeaponConfiguration weaponConfiguration)
    {
        return _weaponFabric.Spawn(weaponConfiguration);
    }

    public Transform Spawn(OtherEffect otherEffect)
    {
        return _otherEffectFabric.Spawn(otherEffect);
    }
}
