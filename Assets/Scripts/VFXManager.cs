using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private List<VFXConfiguration> configurations = new List<VFXConfiguration>();

    private Dictionary<VFXConfiguration, Factory> _factories = new Dictionary<VFXConfiguration, Factory>();
    private void Start()
    {
        foreach (var i in configurations)
        {
            _factories.Add(i,new Factory(i.VisualEffect.gameObject,i.CountElement));
        }
    }

    public VisualEffect GetVisualEffect(VFXConfiguration configuration)
    {
        var factory = _factories[configuration];
        var visualEffect = factory.Create(Vector3.zero).GetComponent<VisualEffect>();
        visualEffect.InitializeFactory(factory);
        return visualEffect;
    }
}
