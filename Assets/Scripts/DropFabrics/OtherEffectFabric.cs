    using System.Collections.Generic;
    using UnityEngine;

    public class OtherEffectFabric
    {
        private Dictionary<OtherEffect, Factory> _factories = new Dictionary<OtherEffect, Factory>();
        
        public OtherEffectFabric(List<OtherEffect> otherEffect, int countElement)
        {
            foreach (var i in otherEffect)
            {
               _factories.Add(i,new Factory(i.gameObject,countElement)); 
            }
        }
        
        public Transform Spawn(OtherEffect otherEffect)
        {
            if (_factories.ContainsKey(otherEffect))
            {
                var factory = _factories[otherEffect];
                var newSpawnEffect = factory.Create(Vector3.zero);
                newSpawnEffect.GetComponent<OtherEffect>().Initialize(factory);
                return newSpawnEffect.transform;
            }
            else
            {
                Debug.LogError($@"Effect {otherEffect} not found");
                return null;
            }
        }
    }