using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    private bool _pointDown;
    
    public bool PointDown => _pointDown;
    
    public void OnPointerUp(PointerEventData eventData)
    {
        _pointDown = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pointDown = true;
    }
}
