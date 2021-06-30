using System;
using UnityEngine;
using Zenject;
public class SaveDataManager : MonoBehaviour
{
    [SerializeField] private bool GenerateNewSave;
    [SerializeField] private WeaponManager _weaponManager;
    
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
        _moneySave.AddMoney(2000);
        Save();
    }

    private void Update()
    {
        if (GenerateNewSave)
        {
            GenerateNewSave = false;
            _upgradeSave.Initialize(_weaponManager.WeaponConfigurations);
            Save();
        }
    }

    public void Save()
    {
        _saveManager.Save(_saveData);
    }
}
