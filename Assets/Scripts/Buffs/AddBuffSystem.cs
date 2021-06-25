using UnityEngine;
public class AddBuffSystem : MonoBehaviour
{
    [SerializeField] private Buffer buffer;
    [SerializeField] private EffectSystem effesSystem;
    [SerializeField] private bool addEffect;

    private void Update()
    {
        if (!addEffect) return;
        buffer.TakeEffect(effesSystem);
        addEffect = false;
    }
}
