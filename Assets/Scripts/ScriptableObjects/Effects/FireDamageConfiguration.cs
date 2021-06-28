using UnityEngine;

namespace ScriptableObjects.Effects
{
    [CreateAssetMenu(menuName = "Buffs/FireDamage")]
    public class FireDamageConfiguration : EffectSystem
    {
        [SerializeField] private float damage;

        public override Effect GenerateEffect(EffectConfiguration effectConfig)
        {
            return new EffectFireDamage(effectConfig.Damageable, timeEffect, damage);
        }
    }
}