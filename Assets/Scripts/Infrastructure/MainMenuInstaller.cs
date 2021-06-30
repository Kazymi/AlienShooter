using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    private WeaponManager _weaponManager;
    private SaveDataManager _saveDataManager;

    public override void InstallBindings()
    {
        Signals();
        BindGameManager();
        BindSaveDataManager();
    }

    private void BindGameManager()
    {
        Container
            .Bind<WeaponManager>()
            .FromInstance(_weaponManager)
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
        Container.DeclareSignal<LoadedSignal>();
        Container.DeclareSignal<SavedSignal>();
    }

    [Inject]
    private void Construct(SaveDataManager saveDataManager,WeaponManager weaponManager)
    {
        _weaponManager = weaponManager;
        _weaponManager.Initialize();
        _saveDataManager = saveDataManager;
    }
}