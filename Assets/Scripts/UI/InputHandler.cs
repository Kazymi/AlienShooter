using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private bool mobile;
    [SerializeField] private FireButton fireButton;
    [SerializeField] private Joystick moveJoystick;

    private Vector2 _moveDirection;

    public Vector2 MoveDirection => _moveDirection;

    private void Update()
    {
        _moveDirection = Direction();
    }

    public bool Fire => fireButton.PointDown || Input.GetKey(KeyCode.Q);

    private Vector2 Direction()
    {
        if (mobile)
        {
            return moveJoystick.Direction;
        }
        else
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}