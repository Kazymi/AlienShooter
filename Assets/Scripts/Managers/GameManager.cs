using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private SignalBus _signalBus;
    private SaveData _saveData;
    private void Start()
    {
        _signalBus.Fire(new ScoreChangedSignal());
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(Save);
        _signalBus.Subscribe<EnemyDeadSignal>(AddScore);
        _signalBus.Subscribe<LoadedSignal>(OnLoaded);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(Save);
        _signalBus.Unsubscribe<LoadedSignal>(OnLoaded);
        _signalBus.Unsubscribe<EnemyDeadSignal>(AddScore);
    }

    private void Save()
    {
    _signalBus.Fire<SaveSignal>();    
    }
    
    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void OnLoaded(LoadedSignal loadedSignal)
    {
        _saveData = loadedSignal.saveData;
    }
    public void AddScore(EnemyDeadSignal deadSignal)
    {
        _saveData.Money += deadSignal.Score;
        _signalBus.Fire<ScoreChangedSignal>();
    }
}
