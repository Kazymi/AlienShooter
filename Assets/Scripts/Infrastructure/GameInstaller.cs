using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private WeaponManager weaponManagerPrefab;
    [SerializeField] private InputHandler inputHandlerPrefab;
    [SerializeField] private VFXManager vfxManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private SaveDataManager saveDataManager;
    [SerializeField] private Player player;

    public override void InstallBindings()
    {
        BindWeaponManager();
        BindInputHandler();
        BindVFXManager();
        BindSpawnManger();
        BindSaveDataManager();
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

    private void BindSaveDataManager()
    {
        Container
            .Bind<SaveDataManager>()
            .FromInstance(saveDataManager)
            .AsSingle();
    }

    private void Signals()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<PlayerDiedSignal>();
        Container.DeclareSignal<LoadedSignal>();
        Container.DeclareSignal<EnemyDiedSignal>();
        Container.DeclareSignal<UpdateHeathSignal>();
        Container.DeclareSignal<ScoreChangedSignal>();
        Container.DeclareSignal<AmmoChangedSignal>();
        Container.DeclareSignal<SavedSignal>();
    }
}