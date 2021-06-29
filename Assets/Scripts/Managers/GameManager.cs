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
        _signalBus.Subscribe<EnemyDiedSignal>(AddScore);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(Save);
        _signalBus.Unsubscribe<EnemyDiedSignal>(AddScore);
    }

    private void Save()
    {
        _signalBus.Fire<SavedSignal>();
    }

    private void AddScore(EnemyDiedSignal diedSignal)
    {
        _moneySave.AddMoney(diedSignal.Score);
        _signalBus.Fire<ScoreChangedSignal>();
    }

    [Inject]
    private void Construct(SignalBus signalBus, SaveDataManager saveDataManager)
    {
        _signalBus = signalBus;
        _moneySave = saveDataManager.MoneySave;
    }
}