using UnityEngine;
using Zenject;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] private bool generateNewSave;
    [SerializeField] private WeaponManager weaponManager;

    private SignalBus _signalBus;
    private SaveData _saveData;
    private SaveManager _saveManager = new SaveManager();

    public UpgradeSave UpgradeSave => _saveData.UpgradeSave;
    public WeaponSave WeaponSave => _saveData.WeaponSave;
    public MoneySave MoneySave => _saveData.MoneySave;

    private void Awake()
    {
        _saveData = _saveManager.Load();
        _saveData.MoneySave.AddMoney(2000);
        Save();
    }

    // TODO: грязь
    private void Update()
    {
        if (generateNewSave)
        {
            generateNewSave = false;
            _saveData.UpgradeSave.Initialize(weaponManager.WeaponConfigurations);
            Save();
        }
    }

    public void Save()
    {
        _saveManager.Save(_saveData);
    }
}