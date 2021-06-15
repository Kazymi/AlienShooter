using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPosition;

    public override void InstallBindings()
    {
        CreateWeaponManager();
    }

    private void CreateWeaponManager()
    {
        var weaponManager = Container
            .InstantiatePrefabForComponent<WeaponManager>(playerPrefab, spawnPosition.position, Quaternion.identity, null);

        Container
              .Bind<WeaponManager>()
              .FromInstance(weaponManager)
              .AsSingle();
    }
}
