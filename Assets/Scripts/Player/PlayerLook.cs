using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform rotatingPlayerTransform;
    
    private Transform _target;
    private bool _lookAtTarget;
    private InputHandler _inputHandler;
    
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
        if (_lookAtTarget && _target != null)
        {
            Vector3 target = new Vector3(_target.position.x, rotatingPlayerTransform.position.y, _target.position.z);
            var rotation = Quaternion.LookRotation(target - rotatingPlayerTransform.position);
            rotatingPlayerTransform.rotation = Quaternion.Slerp(rotatingPlayerTransform.rotation, rotation, Time.deltaTime * 10);
        }
        else
        {
            if (_inputHandler.MoveDirection != Vector2.zero)
            {
                var i = new Vector3(0, Mathf.Atan2(_inputHandler.MoveDirection.x, _inputHandler.MoveDirection.y) * 180 / Mathf.PI, 0);
               rotatingPlayerTransform.rotation= Quaternion.Lerp(rotatingPlayerTransform.rotation, Quaternion.Euler(i), Time.deltaTime*4.0f);

            }
        }
    }
    public void Initialize(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }
}
