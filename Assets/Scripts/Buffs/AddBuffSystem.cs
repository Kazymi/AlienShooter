using UnityEngine;
public class AddBuffSystem : MonoBehaviour
{
    [SerializeField] private Buffer buffer;
    [SerializeField] private EffectConfiguration effectConfiguration;
    [SerializeField] private bool addEffect;

    private void Update()
    {
        if(addEffect) 
        {
         buffer.TakeEffect(effectConfiguration);
         addEffect = false;
        }
    }
}
