using UnityEngine;

namespace ScriptableObjects.Effects
{
    [CreateAssetMenu(menuName = "Buffs/Freeze")]
    public class FreezeConfiguration : EffectSystem
    {
        [SerializeField] private float freezeValue;

        public override Effect GenerateEffect(EffectConfiguration effectConfig)
        {
            return new EffectFreeze(timeEffect, effectConfig.Movenment, freezeValue);
        }
    }
}