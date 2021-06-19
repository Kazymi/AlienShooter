using UnityEngine;
public class AddBuffSystem : MonoBehaviour
{
    [SerializeField] private Buffer buffer;
    [SerializeField] private BuffConfiguration typeBuff;
    [SerializeField] private bool addBuff;

    private void Update()
    {
        // TODO: ???
        if(addBuff) 
        {
            buffer.TakeBuff(typeBuff);
            addBuff = false;
        }
    }
}
