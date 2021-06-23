using UnityEngine;

public class EffectSpawn : MonoBehaviour
{
    [SerializeField] private TypeBuff typeBuff;
    private Factory _factory;
    private EffectSystem _effectSystem;

    public EffectSystem EffectSystem => _effectSystem;
    
    public void Initialize(EffectSystem effectSystem, Factory factory)
    {
        _factory = factory;
        _effectSystem = effectSystem;
    }
    public TypeBuff TypeBuffEffect => typeBuff;

    public void Destroy()
    {
        _factory.Destroy(gameObject);
    }
}
