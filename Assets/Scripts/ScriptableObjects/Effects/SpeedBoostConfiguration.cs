﻿using UnityEngine;

namespace ScriptableObjects.Effects
{
    [CreateAssetMenu(menuName = "Buffs/SpeedBoost")]
    public class SpeedBoostConfiguration : EffectSystem
    {
        [SerializeField] private float speedBostValue;

        public override Effect GenerateEffect(EffectConfiguration effectConfig)
        {
            return new EffectSpeedBoost(effectConfig.Movenment, timeEffect, speedBostValue);
        }
    }
}