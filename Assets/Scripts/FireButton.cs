using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    private bool _pointDown;
    
    // TODO: can be merged into auto-property
    public bool PointDown => _pointDown;
    
    // TODO: you can just use Unity button and subscribe on it's click event, also it gives visual customization options
    // TODO: if you click on image then move finger and only after that let go, _pointDown will remain true 
    public void OnPointerUp(PointerEventData eventData)
    {
        _pointDown = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pointDown = true;
    }
}
