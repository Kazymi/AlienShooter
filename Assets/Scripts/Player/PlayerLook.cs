using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Transform _target;
    private bool _lookAtTarget;
    private Joystick _lookJoystick;
    
    public bool LookAtTarget
    {
        set => _lookAtTarget = value;
    }
    public  Transform Target
    {
        set => _target = value;
    }

    private void Update()
    {
        if (_lookAtTarget)
        {
            transform.LookAt(_target);
        }
        else
        {

            if (_lookJoystick.Direction != Vector2.zero)
            {
                transform.eulerAngles = new Vector3(
                    0, Mathf.Atan2(-_lookJoystick.Horizontal, -_lookJoystick.Vertical) * 180 / Mathf.PI, 0);
            }
        }
    }
    public void Initialize(Joystick joystick)
    {
        _lookJoystick = joystick;
    }
}
