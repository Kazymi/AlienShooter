using UnityEngine;

namespace ScriptableObjects.Effects
{
    [CreateAssetMenu(menuName = "Buffs/FireDamage")]
    public class FireDamage : EffectSystem
    {
        [SerializeField] private float damage;

        public override Effect GenerateEffect(EffectConfig effectConfig)
        {
            return new EffectFireDamage(effectConfig.Damageable, timer, damage);
        }
    }
}