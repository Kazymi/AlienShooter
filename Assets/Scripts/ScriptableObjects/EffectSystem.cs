using UnityEngine;
public abstract class EffectSystem : ScriptableObject
{
    [SerializeField] protected float timer;

    public abstract Effect GenerateEffect(EffectConfig effectConfig);
}
