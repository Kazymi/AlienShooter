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
    [SerializeField] private TMP_Text AmmoText;

    private SaveData _saveData;
    private SignalBus _signalBus;

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDeadSignal>(PlayerDead);
        _signalBus.Subscribe<LoadSignal>(Load);
        _signalBus.Subscribe<UpdateScoreSignal>(UpdateScore);
        _signalBus.Subscribe<UpdateHeathSignal>(UpdateHeal);
        _signalBus.Subscribe<UpdateAmmoSignal>(UpdateAmmo);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<LoadSignal>(Load);
        _signalBus.Unsubscribe<PlayerDeadSignal>(PlayerDead);
        _signalBus.Unsubscribe<UpdateScoreSignal>(UpdateScore);
        _signalBus.Unsubscribe<UpdateHeathSignal>(UpdateHeal);
        _signalBus.Unsubscribe<UpdateAmmoSignal>(UpdateAmmo);
    }

    private void Start()
    {
        UpdateScore();
    }

    public void UpdateHeal(UpdateHeathSignal updateHeathSignal)
    {
        healthBar.value = updateHeathSignal.CurrentHealth;
    }

    public void UpdateAmmo(UpdateAmmoSignal updateAmmoSignal)
    {
        AmmoText.text = updateAmmoSignal.Ammo.ToString();
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