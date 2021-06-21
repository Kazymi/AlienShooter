using UnityEngine;
public class AddBuffSystem : MonoBehaviour
{
    [SerializeField] private Buffer buffer;
    [SerializeField] private Effect typeBuff;
    [SerializeField] private bool addBuff;

    private void Update()
    {
        // TODO: ???
        if(addBuff) 
        {
            buffer.TakeEffect(typeBuff);
            addBuff = false;
        }
    }
}
