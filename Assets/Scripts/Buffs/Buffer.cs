using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Buffer : MonoBehaviour
{
    [SerializeField] private bool player;
    [SerializeField] private bool spawnVFX;
    [SerializeField] private Transform VFXPositionSpawn;

    private Dictionary<TypeBuff, Effect> _effects = new Dictionary<TypeBuff, Effect>();
    private List<VisualEffect> _visualEffects = new List<VisualEffect>();
    private bool _activeEffect;
    private VFXManager _vfxManager;
    private EffectConfiguration _effectConfig;

    public void Initialize(IMovenment changeSpeed, Damageable damageable)
    {
        foreach (var i in _visualEffects)
        {
            i.DestoryEffect();
        }

        _effects = new Dictionary<TypeBuff, Effect>();
        _effectConfig = new EffectConfiguration()
        {
            Damageable = damageable,
            Movenment = changeSpeed
        };
    }
    public void TakeEffect(EffectSystem effectSystem)
    {
        if (_effects.ContainsKey(effectSystem.TypeBuff))
        {
            _effects[effectSystem.TypeBuff].Timer += effectSystem.TimeEffect;
            return;
        }
        var effect = effectSystem.GenerateEffect(_effectConfig);
        _effects.Add(effectSystem.TypeBuff,effect);
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
    private void Construct(VFXManager vfxManager)
    {
        _vfxManager = vfxManager;
    }
    private IEnumerator CheckEffects()
    {
        while (_activeEffect)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            foreach (var i in _effects)
            {
                if (!i.Value.CheckEffect()) continue;
                _effects.Remove(i.Key); break;
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
        _visualEffects.Add(vfx);
        vfx.InitializeEffect(effect);
        vfx.transform.parent = VFXPositionSpawn;
        vfx.transform.localPosition= Vector3.zero;
    }
}