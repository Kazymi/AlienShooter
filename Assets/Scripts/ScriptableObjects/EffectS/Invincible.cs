using UnityEngine;

namespace ScriptableObjects.Effects
{
    [CreateAssetMenu(menuName = "Buffs/Invincible")]
    public class Invincible : EffectSystem
    {

        public override Effect GenerateEffect(EffectConfig effectConfig)
        {
            return new EffectInvincible(timer, effectConfig.Damageable);
        }
    }
}