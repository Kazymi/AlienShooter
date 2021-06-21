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

    public void TakeEffect(TypeBuff effect,float timeEffect,float valueEffect)
    {
        CreateNewEffect(effect,timeEffect,valueEffect);
        if (_activeEffect == false)
        {
            _activeEffect = true;
            StartCoroutine(CheckEffects());
        }
    }

    private void CreateNewEffect(TypeBuff effect, float timeEffect, float valueEffect)
    {
        switch (effect)
        {
            case TypeBuff.Fire:
                _effects.Add(new EffectFireDamage(_damageable, timeEffect, valueEffect));
                return;
            case TypeBuff.Speed:
                _effects.Add(new EffectSpeedBoost(_changeSpeed, timeEffect, valueEffect));
                return;
            case TypeBuff.Invincible:
                _effects.Add(new EffectInvincible(timeEffect,_damageable));
                return;
            case TypeBuff.Freeze:
                _effects.Add(new EffectFreeze(timeEffect,_changeSpeed,valueEffect));
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