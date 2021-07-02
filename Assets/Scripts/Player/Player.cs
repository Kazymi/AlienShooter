using UnityEngine;
using Zenject;

public class Player : MonoBehaviour,IDeathInitialize
{
    [SerializeField] private PlayerConfiguration playerConfiguration;
    [SerializeField] private PlayerScanner playerScanner;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Buffer buffer;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerLook playerLook;

    private SaveDataManager _saveDataManager;
    private InputHandler _inputHandler;

    private void Start()
    {
        playerMovement.Initialize(playerConfiguration,_inputHandler);
        playerLook.Initialize(_inputHandler);
        playerScanner.Initialize(playerLook);
        playerHealth.Initialize(playerConfiguration.Health,this);
        buffer.Initialize(playerMovement,playerHealth);
    }

    [Inject]
    public void Construct(InputHandler inputHandler,SaveDataManager saveDataManager)
    {
        _inputHandler = inputHandler;
        _saveDataManager = saveDataManager;
    }
    
    public void DeadInitialize()
    {
        _saveDataManager.Save();
    }
}
