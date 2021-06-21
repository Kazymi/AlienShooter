using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    private IMovenment _changeSpeed;
    private Damageable _damageable;
    private List<Effect> _effects = new List<Effect>();
    private bool _activeEffect;
   
    public void Initialize(IMovenment changeSpeed, Damageable damageable)
    {
        _changeSpeed = changeSpeed;
        _damageable = damageable;
        DictionaryInitialize();
    }

    public void TakeEffect(EffectConfiguration effectConfiguration)
    {
        CreateNewEffect(effectConfiguration);
        if (_activeEffect == false)
        {
            _activeEffect = true;
            StartCoroutine(CheckEffects());
        }
    }

    private void CreateNewEffect(EffectConfiguration effectConfiguration)
    {
        switch (effectConfiguration.TypeEffect)
        {
            case TypeBuff.Fire:
                _effects.Add(new EffectFireDamage(_damageable, effectConfiguration.TimeEffect, effectConfiguration.ValueEffect));
                return;
            case TypeBuff.Speed:
                _effects.Add(new EffectSpeedBoost(_changeSpeed, effectConfiguration.TimeEffect, effectConfiguration.ValueEffect));
                return;
            case TypeBuff.Invincible:
                _effects.Add(new EffectInvincible(effectConfiguration.TimeEffect,_damageable));
                return;
            case TypeBuff.Freeze:
                _effects.Add(new EffectFreeze(effectConfiguration.TimeEffect,_changeSpeed,effectConfiguration.ValueEffect));
                return;
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