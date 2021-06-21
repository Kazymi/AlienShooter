using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    private IMovenment _changeSpeed;
    private Damageable _damageable;
    private List<Effect> _effects = new List<Effect>();
    private bool _activeEffect;
    private EffectConfig _effectConfig;
    public void Initialize(IMovenment changeSpeed, Damageable damageable)
    {
        _changeSpeed = changeSpeed;
        _damageable = damageable;
        _effectConfig = new EffectConfig()
        {
            Damageable = damageable,
            Movenment = _changeSpeed
        };
        DictionaryInitialize();
    }

    public void TakeEffect(EffectSystem effectSystem)
    {
        _effects.Add(effectSystem.GenerateEffect(_effectConfig));
        if (_activeEffect == false)
        {
            _activeEffect = true;
            StartCoroutine(CheckEffects());
        }
    }

    private void DictionaryInitialize() //???
    {

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
   

}