using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ProjectContextInstaller : MonoInstaller
{
    [SerializeField] private SaveDataManager saveDataManager;
    [SerializeField] private WeaponManager weaponManager;

    public override void InstallBindings()
    {
        BindSaveDataManager();
        BindWeaponManager();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += Initialize;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= Initialize;
    }

    private void BindSaveDataManager()
    {
        Container
            .Bind<SaveDataManager>()
            .FromInstance(saveDataManager)
            .AsSingle();
    }

    private void BindWeaponManager()
    {
        Container
            .Bind<WeaponManager>()
            .FromInstance(weaponManager)
            .AsSingle();
    }

    // TODO: weapon manager can initialize it self on it's own
    public void Initialize(Scene scene, LoadSceneMode mode)
    {
        weaponManager.Initialize();
    }
}