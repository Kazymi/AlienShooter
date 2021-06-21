using UnityEngine;
public class AddBuffSystem : MonoBehaviour
{
    [SerializeField] private Buffer buffer;
    [SerializeField] private TypeBuff typeEffect;
    [SerializeField] private float timer;
    [SerializeField] private float valueEffect;
    [SerializeField] private bool addEffect;

    private void Update()
    {
        if(addEffect) 
        {
         buffer.TakeEffect(typeEffect,timer,valueEffect);
         addEffect = false;
        }
    }
}
