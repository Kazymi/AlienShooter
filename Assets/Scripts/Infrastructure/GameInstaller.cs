using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private InputHandler inputHandlerPrefab;
    [SerializeField] private VFXManager vfxManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private Player player;

    private WeaponManager _weaponManager;
    private SaveDataManager _saveDataManager;
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
            .FromInstance(_weaponManager)
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
            .FromInstance(_saveDataManager)
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
    
    [Inject]
    private void Construct(SaveDataManager saveDataManager,WeaponManager weaponManager)
    {
        weaponManager.Initialize();
        _weaponManager = weaponManager;
        _saveDataManager = saveDataManager;
    }
}