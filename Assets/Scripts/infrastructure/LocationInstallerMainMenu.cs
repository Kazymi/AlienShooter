using UnityEngine;
using Zenject;

public class LocationInstallerMainMenu : MonoInstaller
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private SaveDataManager saveDataManager;
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
            .FromInstance(weaponManager)
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
        Container.DeclareSignal<LoadedSignal>();
        Container.DeclareSignal<SaveSignal>();
    }
    
}
