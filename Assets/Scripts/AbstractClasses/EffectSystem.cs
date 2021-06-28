using UnityEngine;
using UnityEngine.Serialization;

public abstract class EffectSystem : ScriptableObject
{
    [SerializeField] protected float timeEffect;
    [SerializeField] protected VFXConfiguration vfxConfiguration;
    [SerializeField] protected TypeBuff typeBuff;

    public float TimeEffect => timeEffect;
    public TypeBuff TypeBuff => typeBuff;
    public VFXConfiguration VFXConfiguration => vfxConfiguration;
    public abstract Effect GenerateEffect(EffectConfiguration effectConfig);
}



/*

class Effect:

Enable()

Disable()

Tick()


*/