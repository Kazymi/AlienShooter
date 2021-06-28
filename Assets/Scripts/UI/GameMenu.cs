using TMPro;
using UnityEngine;
using Zenject;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private MenuButton menu;
    [SerializeField] private Canvas deadCanvas;
    [SerializeField] private TMP_Text scoreText;

    private SaveData _saveData;
    private SignalBus _signalBus;

    private void Start()
    {
        UpdateScore();
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDeadSignal>(PlayerDead);
        _signalBus.Subscribe<LoadSignal>(Load);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<LoadSignal>(Load);
        _signalBus.Unsubscribe<PlayerDeadSignal>(PlayerDead);
    }

    public void AddScore(int score)
    {
        _saveData.Score += score;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = _saveData.Score.ToString();
    }

    private void Load(LoadSignal loadSignal)
    {
        _saveData = loadSignal.SaveData;
    }
    
    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    
    private void PlayerDead()
    {
        menu.OpenCanvas(deadCanvas);
    }
}
