using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Joystick _lookJoystick;
    private FloatingJoystick _joystick;
    public void Initialize(Joystick joystick)
    {
        _lookJoystick = joystick;
        _joystick = _lookJoystick.GetComponent<FloatingJoystick>();
    }

    private void Update()
    {
        if(_joystick.PointerDown)
        transform.eulerAngles = new Vector3(0, Mathf.Atan2(_lookJoystick.Horizontal, _lookJoystick.Vertical) * 180 / Mathf.PI, 0);
    }
}
