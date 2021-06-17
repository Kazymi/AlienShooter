using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform rotatingPlayerTranform; 
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
            var lookPos = _target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            rotatingPlayerTranform.rotation = Quaternion.Slerp(transform.rotation, rotation,1);
        }
        else
        {

            if (_lookJoystick.Direction != Vector2.zero)
            {
                rotatingPlayerTranform.eulerAngles = new Vector3(
                    0, Mathf.Atan2(-_lookJoystick.Horizontal, -_lookJoystick.Vertical) * 180 / Mathf.PI, 0);
            }
        }
    }
    public void Initialize(Joystick joystick)
    {
        _lookJoystick = joystick;
    }
}
