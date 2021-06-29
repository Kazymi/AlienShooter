using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private SignalBus _signalBus;
    private MoneySave _moneySave;
    private void Start()
    {
        _signalBus.Fire(new ScoreChangedSignal());
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(Save);
        _signalBus.Subscribe<EnemyDeadSignal>(AddScore);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(Save);
        _signalBus.Unsubscribe<EnemyDeadSignal>(AddScore);
    }

    private void Save()
    {
    _signalBus.Fire<SaveSignal>();    
    }
    
    [Inject]
    private void Construct(SignalBus signalBus,SaveDataManager saveDataManager)
    {
        _signalBus = signalBus;
        _moneySave = saveDataManager.MoneySave;
    }
    
    public void AddScore(EnemyDeadSignal deadSignal)
    {
        _moneySave.AddMoney(deadSignal.Score);
        _signalBus.Fire<ScoreChangedSignal>();
    }
}
