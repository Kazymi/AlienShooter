using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private WeaponManager weaponManagerPrefab;
    [SerializeField] private InputHandler inputHandlerPrefab;
    [SerializeField] private VFXManager vfxManager;
    [SerializeField] private EffectManager effectManager;

    public override void InstallBindings()
    {
        CreateWeaponManager();
        CreateInputHandler();
        CreateVFXManager();
        CreateEffectManger();
    }

    private void CreateWeaponManager()
    {
        Container
              .Bind<WeaponManager>()
              .FromInstance(weaponManagerPrefab)
              .AsSingle();
    } 
    private void CreateVFXManager()
    {
        Container
              .Bind<VFXManager>()
              .FromInstance(vfxManager)
              .AsSingle();
    } 
    private void CreateInputHandler()
    {
        Container
              .Bind<InputHandler>()
              .FromInstance(inputHandlerPrefab)
              .AsSingle();
    }

    private void CreateEffectManger()
    {
        Container
            .Bind<EffectManager>()
            .FromInstance(effectManager)
            .AsSingle();
    }
}
