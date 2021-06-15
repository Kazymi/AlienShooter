using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private GameObject weaponManagerPrefab;
    [SerializeField] private GameObject inputHandlerPrefab;
    [SerializeField] private FireButton fireButton;
    [SerializeField] private Transform spawnPosition;

    public override void InstallBindings()
    {
        CreateWeaponManager();
        CreateInputHandler();
    }

    private void CreateWeaponManager()
    {
        var weaponManager = Container
            .InstantiatePrefabForComponent<WeaponManager>(weaponManagerPrefab, spawnPosition.position, Quaternion.identity, null);

        Container
              .Bind<WeaponManager>()
              .FromInstance(weaponManager)
              .AsSingle();
    } 
    private void CreateInputHandler()
    {
        var inputHandler = Container
            .InstantiatePrefabForComponent<InputHandler>(inputHandlerPrefab, spawnPosition.position, Quaternion.identity, null);
        inputHandler.FireButton = fireButton;
        Container
              .Bind<InputHandler>()
              .FromInstance(inputHandler)
              .AsSingle();
    }
}
