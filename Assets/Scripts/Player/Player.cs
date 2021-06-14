using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick lookJoystick;
    [SerializeField] private PlayerConfiguration playerConfiguration;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerLook playerLook;

    private void Start()
    {
        playerMove.Initialize(playerConfiguration,moveJoystick);
        playerLook.Initialize(lookJoystick);
    }
}
