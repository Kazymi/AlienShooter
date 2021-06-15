using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick lookJoystick;
    [SerializeField] private PlayerConfiguration playerConfiguration;
    [SerializeField] private WeaponControl weaponControl;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerLook playerLook;

    public WeaponControl WeaponControl => weaponControl;
    private void Start()
    {
        playerMove.Initialize(playerConfiguration,moveJoystick);
        playerLook.Initialize(lookJoystick);
    }
}
