using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
