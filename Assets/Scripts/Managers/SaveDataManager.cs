using UnityEngine;
using Zenject;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] private bool generateNewSave;
    [SerializeField] private WeaponManager weaponManager;

    private SignalBus _signalBus;
    private SaveData _saveData;
    private SaveManager _saveManager = new SaveManager();
    private UpgradeSave _upgradeSave;
    private WeaponSave _weaponSave;
    private MoneySave _moneySave;

    public UpgradeSave UpgradeSave => _upgradeSave;
    public WeaponSave WeaponSave => _weaponSave;
    public MoneySave MoneySave => _moneySave;

    private void Awake()
    {
        _saveData = _saveManager.Load();
        _upgradeSave = new UpgradeSave(_saveData);
        _weaponSave = new WeaponSave(_saveData);
        _moneySave = new MoneySave(_saveData);
        // TODO: I guess that was for debugging purposes
        _moneySave.AddMoney(2000);
        Save();
    }

    // TODO: грязь
    private void Update()
    {
        if (generateNewSave)
        {
            generateNewSave = false;
            _upgradeSave.Initialize(weaponManager.WeaponConfigurations);
            Save();
        }
    }

    public void Save()
    {
        _saveManager.Save(_saveData);
    }
}