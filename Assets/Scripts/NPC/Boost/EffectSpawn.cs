using UnityEngine;

public class EffectSpawn : MonoBehaviour
{
    [SerializeField] private EffectSystem effectSystem;
    [SerializeField] private TypeBuff typeBuff;

    public EffectSystem CurrentEffectSystem
    {
        get => effectSystem;
        set => effectSystem = value;
    }
    public TypeBuff TypeBuff => typeBuff;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
