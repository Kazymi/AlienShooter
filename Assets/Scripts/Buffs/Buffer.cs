using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Buffer : MonoBehaviour
{
    [SerializeField] private bool player;
    [SerializeField] private bool spawnVFX;
    [SerializeField] private Transform VFXPositionSpawn;
    
    private List<Effect> _effects = new List<Effect>();
    private bool _activeEffect;
    private VFXManager _vfxManager;
    private EffectConfig _effectConfig;
    public void Initialize(IMovenment changeSpeed, Damageable damageable)
    {
        _effectConfig = new EffectConfig()
        {
            Damageable = damageable,
            Movenment = changeSpeed
        };
    }
    public void TakeEffect(EffectSystem effectSystem)
    {
        var effect = effectSystem.GenerateEffect(_effectConfig);
        _effects.Add(effect);
        if (spawnVFX && effectSystem.VFXConfiguration != null)
        {
            if (effectSystem.VFXConfiguration.OnlyPlayer)
            {
                if (player) SpawnVFX(effectSystem.VFXConfiguration, effect);
            }
            else
            {
                SpawnVFX(effectSystem.VFXConfiguration, effect);
            }
        }
        if (_activeEffect == false)
        {
            _activeEffect = true;
            StartCoroutine(CheckEffects());
        }
    }

    [Inject]
    public void Construct(VFXManager vfxManager)
    {
        _vfxManager = vfxManager;
        Debug.Log("++");
    }
    IEnumerator CheckEffects()
    {
        while (_activeEffect)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            foreach (var i in _effects)
            {
                if(i.CheckEffect()) {_effects.Remove(i); break;}
            }
            if (_effects.Count == 0)
            {
                _activeEffect = false;
            }
        }
    }

    private void SpawnVFX(VFXConfiguration vfxConfiguration,Effect effect)
    {
        var vfx = _vfxManager.GetVisualEffect(vfxConfiguration);
        vfx.InitializeEffect(effect);
        vfx.transform.parent = VFXPositionSpawn;
        vfx.transform.localPosition= Vector3.zero;
    }
}