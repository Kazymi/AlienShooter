using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
public class SaveDataManager : MonoInstaller
{
    private SignalBus _signalBus;
    private SaveData _saveData;
    private SaveManager _saveManager = new SaveManager();
    private WeaponSave _weaponSave;
    private MoneySave _moneySave;

    public WeaponSave WeaponSave => _weaponSave;
    public MoneySave MoneySave => _moneySave;

    public override void InstallBindings()
    {
        Container.Bind(typeof(SaveDataManager)).FromInstance(this).AsSingle();
    }

    private void Awake()
    {
        _saveData = _saveManager.Load();
        Debug.Log(_saveData.Money);
        _weaponSave = new WeaponSave(_saveData);
        _moneySave = new MoneySave(_saveData);
        _moneySave.AddMoney(2000);
        Save();
    }

    public void Save()
    {
        Debug.Log(_moneySave.Money);
        Debug.Log(_saveData.Money);
        _saveManager.Save(_saveData);
    }
}
