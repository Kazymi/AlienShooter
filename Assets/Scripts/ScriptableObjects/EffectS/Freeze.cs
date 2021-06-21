using UnityEngine;

namespace ScriptableObjects.Effects
{
    [CreateAssetMenu(menuName = "Buffs/Freeze")]
    public class Freeze : EffectSystem
    {
        [SerializeField] private float freezeValue;

        public override Effect GenerateEffect(EffectConfig effectConfig)
        {
            return new EffectFreeze(timer,effectConfig.Movenment,freezeValue);
        }
    }
}