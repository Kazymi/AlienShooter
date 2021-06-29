using UnityEngine;
using Zenject;

public class LocationInstallerMainMenu : MonoInstaller
{
    [SerializeField] private WeaponManager weaponManager;

    public override void InstallBindings()
    {
        Signals();
        BindGameManager();
    }

    private void BindGameManager()
    {
        Container
            .Bind<WeaponManager>()
            .FromInstance(weaponManager)
            .AsSingle();
    }

    private void Signals()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<LoadedSignal>();
        Container.DeclareSignal<SaveSignal>();
    }
}
