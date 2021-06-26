using System.Collections.Generic;
using UnityEngine;

public class EffectFabric
{
    private readonly Dictionary<TypeBuff, Factory> _factories = new Dictionary<TypeBuff, Factory>();

    public EffectFabric(IEnumerable<EffectSpawn> effectSpawns,int countElement,Transform parent)
    {
        foreach (var i in effectSpawns)
        {
            Debug.Log(i.TypeBuffEffect);
            _factories.Add(i.TypeBuffEffect,new Factory(i.gameObject, countElement,parent));
        }
    }

    public Transform Spawn(EffectSystem effectSystem)
    {
        if (_factories.ContainsKey(effectSystem.TypeBuff))
        {
            var factory = _factories[effectSystem.TypeBuff];
            var newSpawnEffect = factory.Create(Vector3.zero);
            newSpawnEffect.GetComponent<EffectSpawn>().Initialize(effectSystem,factory);;
            return newSpawnEffect.transform;
        }
        else
        {
            Debug.LogError($@"Effect {effectSystem} not found");
            return null;
        }
    }
}
