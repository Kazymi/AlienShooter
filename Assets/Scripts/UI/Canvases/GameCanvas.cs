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

    private SaveData _saveData;
    private SignalBus _signalBus;

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
        _signalBus.Subscribe<LoadedSignal>(OnLoaded);
        _signalBus.Subscribe<ScoreChangedSignal>(OnScoreChanged);
        _signalBus.Subscribe<UpdateHeathSignal>(OnUpdateHeal);
        _signalBus.Subscribe<UpdateAmmoSignal>(OnUpdateAmmo);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<LoadedSignal>(OnLoaded);
        _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDied);
        _signalBus.Unsubscribe<ScoreChangedSignal>(OnScoreChanged);
        _signalBus.Unsubscribe<UpdateHeathSignal>(OnUpdateHeal);
        _signalBus.Unsubscribe<UpdateAmmoSignal>(OnUpdateAmmo);
    }

    // TODO: just fire score signal after data has been loaded
    /*private void Start()
    {
        OnUpdateScore();
    }*/

    public void OnUpdateHeal(UpdateHeathSignal updateHeathSignal)
    {
        healthBar.value = updateHeathSignal.CurrentHealth;
    }

    public void OnUpdateAmmo(UpdateAmmoSignal updateAmmoSignal)
    {
        ammoText.text = updateAmmoSignal.Ammo.ToString();
    }

    private void OnScoreChanged(ScoreChangedSignal changedSignal)
    {
        // TODO:
        // scoreText.text = _saveData.Score.ToString();
        scoreText.text = changedSignal.Score.ToString();
    }

    private void OnLoaded(LoadedSignal loadedSignal)
    {
        _saveData = loadedSignal.saveData;
    }

    private void OnPlayerDied()
    {
        menu.OpenCanvas(deadCanvas);
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
}