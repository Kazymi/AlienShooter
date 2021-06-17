using UnityEngine;

public class Player : MonoBehaviour,IDeathInitialize
{
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private PlayerConfiguration playerConfiguration;
    [SerializeField] private WeaponControl weaponControl;
    [SerializeField] private PlayerScanner playerScanner;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerLook playerLook;

    public WeaponControl WeaponControl => weaponControl;
    private void Start()
    {
        playerMove.Initialize(playerConfiguration,moveJoystick);
        playerLook.Initialize(moveJoystick);
        playerScanner.Initialize(playerLook);
        _playerHealth.Initialize(playerConfiguration.HP,this);
    }

    public void DeadInitialize()
    {
        
    }
}
