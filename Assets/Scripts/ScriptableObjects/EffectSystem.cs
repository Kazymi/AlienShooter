using UnityEngine;
public abstract class EffectSystem : ScriptableObject
{
    [SerializeField] protected float timer;
    [SerializeField] protected VFXConfiguration vfxConfiguration;
    [SerializeField] protected TypeBuff typeBuff;

    public float Timer => timer;
    public TypeBuff TypeBuff => typeBuff;
    public VFXConfiguration VFXConfiguration => vfxConfiguration;
    public abstract Effect GenerateEffect(EffectConfig effectConfig);
}
