using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    private Button _button;
    // TODO: can be merged into auto-property
    public bool PointDown { get; private set; }

    // TODO: you can just use Unity button and subscribe on it's click event, also it gives visual customization options
    // TODO: if you click on image then move finger and only after that let go, _pointDown will remain true 
    public void OnPointerUp(PointerEventData eventData)
    {
        PointDown = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PointDown = true;
    }
}
