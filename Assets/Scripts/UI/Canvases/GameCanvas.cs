using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private CanvasPicker menu;
    [SerializeField] private Canvas deadCanvas;
    [SerializeField] private TMP_Text scoreText;

    private SaveData _saveData;
    private SignalBus _signalBus;

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

    private void Start()
    {
        UpdateScore();
    }

    public void UpdateHeal(float currentHealth)
    {
        healthBar.value = currentHealth;
    }

    public void AddScore(int score)
    {
        // TODO: move to game manager
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