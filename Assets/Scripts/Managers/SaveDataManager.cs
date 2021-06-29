using System;
using UnityEngine;
using Zenject;

public class SaveDataManager : MonoBehaviour
{
    private SignalBus _signalBus;
    private SaveData _saveData;
    private SaveManager _saveManager = new SaveManager();
    
    private void Start()
    {
        _saveData = _saveManager.Load();
        _signalBus.Fire(new LoadedSignal(_saveData));
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<SaveSignal>(Save);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<SaveSignal>(Save);
    }

    private void Save()
    {
        _saveManager.Save(_saveData);
    }
    
    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
}
