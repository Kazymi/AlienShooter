using UnityEngine;

namespace ScriptableObjects.Effects
{
    [CreateAssetMenu(menuName = "Buffs/Invincible")]
    public class InvincibleConfiguration : EffectSystem
    {
        public override Effect GenerateEffect(EffectConfiguration effectConfig)
        {
            return new EffectInvincible(timeEffect, effectConfig.Damageable);
        }
    }
}