using UnityEngine;
using Zenject;

public class GamaManager : MonoBehaviour
{
    private SignalBus _signalBus;
    private SaveData _saveData;
    private SaveManager _saveManager = new SaveManager();
    
    private void Start()
    {
        _saveData = _saveManager.Load();
        _signalBus.Fire(new LoadSignal(_saveData));
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDeadSignal>(Save);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDeadSignal>(Save);;
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void Save()
    {
        _saveManager.Save(_saveData);
    }
}
