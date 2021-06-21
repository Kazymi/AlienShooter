using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : MonoBehaviour
{
   private IChangeSpeed _changeSpeed;
   private Damageable _damageable;
   private Dictionary<TypeBuff, Type> effects = new Dictionary<TypeBuff, Type>(); 
   private List<Effect> _buffConfigurations = new List<Effect>();
   private bool _activeEffect;
   
   public void Initialize(IChangeSpeed changeSpeed, Damageable damageable)
   {
      _changeSpeed = changeSpeed;
      _damageable = damageable;
   }

   public void TakeEffect(TypeBuff effect,float timeEffect)
   {
      
      if (_activeEffect == false)
      {
         _activeEffect = true;
         StartCoroutine(CheckBuffs());
      }
   }

   IEnumerator CheckBuffs()
   {
      while (_activeEffect)
      {
         yield return new WaitForSeconds(Time.deltaTime);
         foreach (var i in _buffConfigurations)
         {
           if(i.CheckBuff()) _buffConfigurations.Remove(i);
           break;
         }
         if (_buffConfigurations.Count == 0)
         {
            _activeEffect = false;
         }
      }
   }
   

}