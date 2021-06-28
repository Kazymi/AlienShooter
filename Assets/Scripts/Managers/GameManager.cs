using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private SignalBus _signalBus;
    private SaveData _saveData;
    private SaveManager _saveManager = new SaveManager();
    
    private void Awake()
    {
        _saveData = _saveManager.Load();
        _signalBus.Fire(new LoadSignal(_saveData));
        _signalBus.Fire<UpdateScoreSignal>();
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDeadSignal>(Save);
        _signalBus.Subscribe<EnemyDeadSignal>(AddScore);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDeadSignal>(Save);
        _signalBus.Unsubscribe<EnemyDeadSignal>(AddScore);
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

    public void AddScore(EnemyDeadSignal deadSignal)
    {
        _saveData.Score += deadSignal.Score;
        _signalBus.Fire<UpdateScoreSignal>();
    }
}
