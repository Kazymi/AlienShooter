using UnityEngine;

public class Player : MonoBehaviour,IDeathInitialize
{
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private PlayerConfiguration playerConfiguration;
    [SerializeField] private WeaponControl weaponControl;
    [SerializeField] private PlayerScanner playerScanner;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Buffer buffer;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerLook playerLook;

    public WeaponControl WeaponControl => weaponControl;
    
    // TODO: can be completely removed by creating dedicated injection installer
    private void Start()
    {
        playerMove.Initialize(playerConfiguration,moveJoystick);
        playerLook.Initialize(moveJoystick);
        playerScanner.Initialize(playerLook);
        playerHealth.Initialize(playerConfiguration.HP,this);
        buffer.Initialize(playerMove,playerHealth);
    }
    
    // TODO: ???
    public void DeadInitialize()
    {
        
    }
}
