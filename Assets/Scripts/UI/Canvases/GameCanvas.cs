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
    [SerializeField] private TMP_Text ammoText;

    private MoneySave _moneySave;
    private SignalBus _signalBus;

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
        _signalBus.Subscribe<ScoreChangedSignal>(OnScoreChanged);
        _signalBus.Subscribe<UpdateHeathSignal>(OnUpdateHeal);
        _signalBus.Subscribe<AmmoChangedSignal>(OnUpdateAmmo);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDied);
        _signalBus.Unsubscribe<ScoreChangedSignal>(OnScoreChanged);
        _signalBus.Unsubscribe<UpdateHeathSignal>(OnUpdateHeal);
        _signalBus.Unsubscribe<AmmoChangedSignal>(OnUpdateAmmo);
    }

    private void OnUpdateHeal(UpdateHeathSignal updateHeathSignal)
    {
        healthBar.value = updateHeathSignal.CurrentHealth;
    }

    private void OnUpdateAmmo(AmmoChangedSignal ammoChangedSignal)
    {
        ammoText.text = ammoChangedSignal.Ammo.ToString();
    }

    private void OnScoreChanged()
    {
        scoreText.text = _moneySave.Money.ToString();
    }

    private void OnPlayerDied()
    {
        menu.OpenCanvas(deadCanvas);
    }

    [Inject]
    private void Construct(SignalBus signalBus, SaveDataManager saveDataManager)
    {
        _signalBus = signalBus;
        _moneySave = saveDataManager.MoneySave;
        OnScoreChanged();
    }
}