using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public bool PointDown { get; private set; }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        PointDown = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PointDown = true;
    }
}
