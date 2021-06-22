using UnityEngine;
public abstract class EffectSystem : ScriptableObject
{
    [SerializeField] protected float timer;
    [SerializeField] protected VFXConfiguration vfxConfiguration;

    public VFXConfiguration VFXConfiguration => vfxConfiguration;
    public abstract Effect GenerateEffect(EffectConfig effectConfig);
}
