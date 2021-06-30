using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform weaponSpawnPosition;

    private WeaponManager _weaponManager;
    private List<Weapon> _weapons;
    private int _currentID;
    private WeaponSave _weaponSave;
    private MoneySave _moneySave;
    private SaveDataManager _saveDataManager;
    private WeaponCharacteristics _characteristicsCurrentWeapon;

    public WeaponCharacteristics WeaponCharacteristics => _characteristicsCurrentWeapon;
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

    public void NextWeapon()
    {
        _currentID++;
        if (_currentID == _weapons.Count) _currentID = 0;
        SpawnWeapon(_weapons[_currentID]);
    }

    public void PastWeapon()
    {
        _currentID--;
        if (_currentID < 0) _currentID = _weapons.Count - 1;
        SpawnWeapon(_weapons[_currentID]);
    }

    public void UpdateWeaponState()
    {
        Price = _weaponManager.GetWeaponConfigurationByWeapon(_weapons[_currentID]).Price;
        UnlockBuy = UnlockBuyingWeapon(_weapons[_currentID]);
        var weapon = _weaponManager.GetWeaponConfigurationByWeapon(_weapons[_currentID]);
        var ammo = weapon.AmmoConfiguration;
        
        Debug.Log(weapon +"11"+ammo);
        _characteristicsCurrentWeapon = new WeaponCharacteristics(
            ammo.Damage,
            weapon.FireRate,
            weapon.TimeReloaded,
            ammo.SpeedAmmo,
            weapon.MaxAmmo
        );
    }

    public void Buy()
    {
        if (!UnlockBuy) return;
        _moneySave.RemoveMoney(Price);
        _weaponSave.UnlockNewWeapon(_weaponManager.GetNameByWeapon(_weapons[_currentID]));
        _saveDataManager.Save();
    }

    public void EquipWeapon()
    {
        _weaponSave.NewSelectedWeapon(_weaponManager.GetNameByWeapon(_weapons[_currentID]));
        _saveDataManager.Save();
    }

    public bool CheckBoughtWeapon()
    {
        foreach (var i in _weaponSave.UnlockedWeapons)
        {
            if (_weaponManager.GetNameByWeapon(_weapons[_currentID]) == i) return true;
        }
        return false;
    }

    private bool UnlockBuyingWeapon(Weapon weapon)
    {
        var returnValue = true;
        returnValue = CheckBoughtWeapon() == false;
        if (_moneySave.CompareMoney(Price) == false) returnValue = false;
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

    [Inject]
    private void Construct(WeaponManager weaponManager, SignalBus signalBus, SaveDataManager saveDataManager)
    {
        _weaponManager = weaponManager;
        _saveDataManager = saveDataManager;
        _moneySave = saveDataManager.MoneySave;
        _weaponSave = saveDataManager.WeaponSave;
    }
}