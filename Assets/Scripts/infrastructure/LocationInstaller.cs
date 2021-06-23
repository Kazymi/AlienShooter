using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private WeaponManager weaponManagerPrefab;
    [SerializeField] private InputHandler inputHandlerPrefab;
    [SerializeField] private VFXManager vfxManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private Player player;

    public override void InstallBindings()
    {
        BindWeaponManager();
        BindInputHandler();
        BindVFXManager();
        BindSpawnManger();
        BindPlayer();;
    }

    private void BindWeaponManager()
    {
        Container
              .Bind<WeaponManager>()
              .FromInstance(weaponManagerPrefab)
              .AsSingle();
    } 
    private void BindVFXManager()
    {
        Container
              .Bind<VFXManager>()
              .FromInstance(vfxManager)
              .AsSingle();
    } 
    private void BindInputHandler()
    {
        Container
              .Bind<InputHandler>()
              .FromInstance(inputHandlerPrefab)
              .AsSingle();
    }

    private void BindSpawnManger()
    {
        Container
            .Bind<SpawnManager>()
            .FromInstance(spawnManager)
            .AsSingle();
    }

    private void BindPlayer()
    {
        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();
    }
}
