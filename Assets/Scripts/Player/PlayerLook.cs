using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Joystick _lookJoystick;
    public void Initialize(Joystick joystick)
    {
        _lookJoystick = joystick;
    }

    private void Update()
    {
        if(_lookJoystick.Direction != Vector2.zero)
        transform.eulerAngles = new Vector3(0, Mathf.Atan2(-_lookJoystick.Horizontal, -_lookJoystick.Vertical) * 180 / Mathf.PI, 0);
    }
}
