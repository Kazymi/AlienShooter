using UnityEngine;
using Zenject;

public class ProjectContextInstaller : MonoInstaller,IInitializable
{
    [SerializeField] private SaveDataManager saveDataManager;

    public override void InstallBindings()
    {
        //BindSaveDataManager();
    }

    private void BindSaveDataManager()
    {
        Container
            .Bind<SaveDataManager>()
            .FromInstance(saveDataManager)
            .AsSingle();
    }

    public void Initialize()
    {
        BindSaveDataManager();
    }
}
