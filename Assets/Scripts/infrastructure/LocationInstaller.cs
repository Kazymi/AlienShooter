using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private WeaponManager weaponManagerPrefab;
    [SerializeField] private InputHandler inputHandlerPrefab;

    public override void InstallBindings()
    {
        CreateWeaponManager();
        CreateInputHandler();
    }

    private void CreateWeaponManager()
    {
        Container
              .Bind<WeaponManager>()
              .FromInstance(weaponManagerPrefab)
              .AsSingle();
    } 
    private void CreateInputHandler()
    {
        Container
              .Bind<InputHandler>()
              .FromInstance(inputHandlerPrefab)
              .AsSingle();
    }
}
