using UnityEngine;

namespace ScriptableObjects.Effects
{
    [CreateAssetMenu(menuName = "Buffs/SpeedBoost")]
    public class SpeedBoost : EffectSystem
    {
        [SerializeField] private float speedBostValue;

        public override Effect GenerateEffect(EffectConfig effectConfig)
        {
            return new EffectSpeedBoost(effectConfig.Movenment, timer, speedBostValue);
        }
    }
}