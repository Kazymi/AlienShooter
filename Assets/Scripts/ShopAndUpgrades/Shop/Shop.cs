using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform weaponSpawnPosition;

    private WeaponManager _weaponManager;
    private List<Weapon> _weapons;
    private int _currentID;
    private SaveData _saveData;
    private SignalBus _signalBus;

    public bool UnlockBuy { get; private set; }
    public int Price { get; private set; }

    private void Start()
    {
        _weapons = _weaponManager.GetAllWeapon();
        foreach (var i in _weapons)
        {
            i.GetComponent<Weapon>().enabled = false;
        }
        SpawnWeapon(_weapons[0]);
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<LoadedSignal>(OnLoaded);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<LoadedSignal>(OnLoaded);
    }

    public void NextWeapon()
    {
        _currentID++;
        if (_currentID == _weapons.Count) _currentID = 0;
        SpawnWeapon(_weapons[_currentID]);
    }

    public void PastWeapon()
    {
        _currentID--;
        if (_currentID < 0) _currentID = _weapons.Count-1;
        SpawnWeapon(_weapons[_currentID]);
    }

    public void UpdateWeaponState()
    {
        Price = _weaponManager.GetWeaponConfigurationByWeapon(_weapons[_currentID]).Price;
        UnlockBuy = UnlockBuyingWeapon(_weapons[_currentID]);
    }
    
    public void Buy()
    {
        if (!UnlockBuy) return;
        _saveData.Money -= Price;
        _saveData.UnlockedWeapon.Add(_weaponManager.GetNameByWeapon(_weapons[_currentID]));
        _signalBus.Fire<SaveSignal>();
    }

    public void EquipWeapon()
    {
        _saveData.SelectedWeaponName = _weaponManager.GetNameByWeapon(_weapons[_currentID]);
        _signalBus.Fire<SaveSignal>();
    }
    
    public bool CheckBoughtWeapon()
    {
        foreach (var i in _saveData.UnlockedWeapon)
        {
            if(_weaponManager.GetNameByWeapon(_weapons[_currentID]) == i) return true;
        }
        return false;
    }
    
    private bool UnlockBuyingWeapon(Weapon weapon)
    {
        var returnValue = true;
        returnValue = !CheckBoughtWeapon();
        if (Price > _saveData.Money) returnValue = false;
        return returnValue;
    }
    
    private void SpawnWeapon(Weapon spawnWeapon)
    {
        foreach (var i in _weapons)
        {
            i.transform.parent = _weaponManager.transform;
            i.gameObject.SetActive(false);
        }
        var transformWeapon = spawnWeapon.transform;
        transformWeapon.parent = weaponSpawnPosition;
        transformWeapon.localPosition = Vector3.zero;
        transformWeapon.localRotation = Quaternion.identity;
        spawnWeapon.gameObject.SetActive(true);
        UpdateWeaponState();
    }

    private void OnLoaded(LoadedSignal loadedSignal)
    {
        _saveData = loadedSignal.saveData;
    }
    
    [Inject]
    private void Construct(WeaponManager weaponManager,SignalBus signalBus)
    {
        _weaponManager = weaponManager;
        _signalBus = signalBus;
    }
}