using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private List<EffectSpawn> effectSystems = new List<EffectSpawn>();
    [SerializeField] private int elementsOnStart;
    
    private readonly Dictionary<TypeBuff, Factory> _factories = new Dictionary<TypeBuff, Factory>();

    private void Start()
    {
        foreach (var i in effectSystems)
        {
           _factories.Add(i.CurrentEffectSystem.TypeBuff,new Factory(i.gameObject, elementsOnStart));
        }
    }

    public Transform SpawnEffect(EffectSystem effectSystem)
    {
        if (_factories.ContainsKey(effectSystem.TypeBuff))
        {
            var newSpawnEffect = _factories[effectSystem.TypeBuff].Create(Vector3.zero);
            newSpawnEffect.GetComponent<EffectSpawn>().CurrentEffectSystem = effectSystem;
            return newSpawnEffect.transform;
        }
        else
        {
            Debug.LogError($@"Effect {effectSystem} not found");
            return null;
        }
    }
}
