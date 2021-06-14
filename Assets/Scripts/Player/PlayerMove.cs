using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private bool Mobile = true;

    private PlayerConfiguration _playerConfiguration;
    private Joystick _joystick;
    private Vector3 _moveDir = Vector3.zero;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();    
    }
    private void Update()
    {
        Move();
    }
    public void Initialized(PlayerConfiguration player,Joystick joystick)
    {
        _playerConfiguration = player;
        _joystick = joystick;
    }
    private void Move()
    {
        if (Mobile)
            _moveDir = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        else
            _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDir = transform.TransformDirection(_moveDir);
        _moveDir *= _playerConfiguration.Speed*Time.deltaTime;
        _characterController.Move(_moveDir);
    }
}
