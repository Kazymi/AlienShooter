using UnityEngine;
using Zenject;

public class Player : MonoBehaviour,IDeathInitialize
{
    [SerializeField] private PlayerConfiguration playerConfiguration;
    [SerializeField] private WeaponControl weaponControl;
    [SerializeField] private PlayerScanner playerScanner;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Buffer buffer;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerLook playerLook;

    private InputHandler _inputHandler;
    public WeaponControl WeaponControl => weaponControl;
    
    private void Start()
    {
        playerMove.Initialize(playerConfiguration,_inputHandler);
        playerLook.Initialize(_inputHandler);
        playerScanner.Initialize(playerLook);
        playerHealth.Initialize(playerConfiguration.HP,this);
        buffer.Initialize(playerMove,playerHealth);
    }

    [Inject]
    public void Construct(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }
    
    public void DeadInitialize()
    {
        
    }
}
