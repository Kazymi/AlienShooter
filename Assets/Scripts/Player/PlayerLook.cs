using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform rotatingPlayerTransform; 
    private Transform _target;
    private bool _lookAtTarget;
    // TODO: should read Vector2 from some Input class
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
            Vector3 target = new Vector3(_target.position.x, rotatingPlayerTransform.position.y, _target.position.z);
            var rotation = Quaternion.LookRotation(target - rotatingPlayerTransform.position);
            rotatingPlayerTransform.rotation = Quaternion.Slerp(rotatingPlayerTransform.rotation, rotation, Time.deltaTime * 10);
        }
        else
        {
            if (_lookJoystick.Direction != Vector2.zero)
            {
                rotatingPlayerTransform.eulerAngles = new Vector3(
                    0, Mathf.Atan2(-_lookJoystick.Horizontal, -_lookJoystick.Vertical) * 180 / Mathf.PI, 0);
            }
        }
    }
    public void Initialize(Joystick joystick)
    {
        _lookJoystick = joystick;
    }
}
