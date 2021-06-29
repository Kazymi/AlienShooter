using System;
using UnityEngine;
using Zenject;

public class SaveDataManager : MonoBehaviour
{
    private SignalBus _signalBus;
    private SaveData _saveData;
    private SaveManager _saveManager = new SaveManager();
    private WeaponSave _weaponSave;
    private MoneySave _moneySave;

    public WeaponSave WeaponSave => _weaponSave;
    public MoneySave MoneySave => _moneySave;


    private void Awake()
    {
        _saveData = _saveManager.Load();
        _weaponSave = new WeaponSave(_saveData);
        _moneySave = new MoneySave(_saveData);
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<SaveSignal>(Save);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<SaveSignal>(Save);
    }

    private void Save()
    {
        _saveManager.Save(_saveData);
    }
    
    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
}
