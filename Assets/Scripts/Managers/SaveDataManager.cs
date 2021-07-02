using UnityEngine;
using Zenject;

public class SaveDataManager : MonoBehaviour
{
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
        if (_saveData != null) return;
        _saveData = new SaveData();
        UpgradeSave.Initialize(weaponManager.WeaponConfigurations);
        _saveData.MoneySave.AddMoney(10000);
        Save();
    }

    public void Save()
    {
        _saveManager.Save(_saveData);
    }
}