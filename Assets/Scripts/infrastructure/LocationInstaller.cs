using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private WeaponManager weaponManagerPrefab;
    [SerializeField] private InputHandler inputHandlerPrefab;
    [SerializeField] private VFXManager vfxManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private Player player;
    [SerializeField] private GameMenu gameMenu;

    public override void InstallBindings()
    {
        BindWeaponManager();
        BindInputHandler();
        BindVFXManager();
        BindGameMenu();
        BindSpawnManger();
        BindPlayer();
        Signals();
    }

    private void BindWeaponManager()
    {
        Container
              .Bind<WeaponManager>()
              .FromInstance(weaponManagerPrefab)
              .AsSingle();
    } 
    private void BindGameMenu()
    {
        Container
            .Bind<GameMenu>()
            .FromInstance(gameMenu)
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

    private void Signals()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<PlayerDeadSignal>();
        Container.DeclareSignal<LoadSignal>();
    }
}
