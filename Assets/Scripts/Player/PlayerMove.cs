using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private bool mobile = true;
    private PlayerConfiguration _playerConfiguration;
    private Joystick _joystick;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void Initialize(PlayerConfiguration playerConfiguration, Joystick joystick)
    {
        _playerConfiguration = playerConfiguration;
        _joystick = joystick;
    }

    private void Move()
    {
        var moveDir = mobile ? new Vector3(-_joystick.Horizontal, 0, -_joystick.Vertical) : new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveDir = transform.TransformDirection(moveDir);
        moveDir *= _playerConfiguration.Speed * Time.deltaTime;
        _characterController.Move(moveDir);
    }
}