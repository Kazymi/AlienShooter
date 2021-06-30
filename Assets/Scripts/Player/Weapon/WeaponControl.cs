using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] private string startWeapon;
    [SerializeField] private Transform positionWeapon;
    [SerializeField] private Transform ammoParent;

    private Weapon _currentWeapon;
    private InputHandler _inputHandler;
    private List<WeaponConfiguration> _spawnedWeapon = new List<WeaponConfiguration>() { null, null };
    private WeaponManager _weaponManager;
    private int _idCurrentGun;
    private SignalBus _signalBus;
    private UpgradeSave _upgradeSave;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextWeapon();
        }

        if (_currentWeapon == null) return;
        if (!_inputHandler.Fire) return;
        _currentWeapon.Fire();
    }

    public void NewWeapon(WeaponConfiguration weaponConfiguration)
    {
        for (var i = 0; i < _spawnedWeapon.Count; i++)
        {
            if (_spawnedWeapon[i] != null) continue;
            SetWeapon(weaponConfiguration, i);
            return;
        }
        SetWeapon(weaponConfiguration, _idCurrentGun);
    }

    private void NextWeapon()
    {
        if (_spawnedWeapon[0] == null && _spawnedWeapon[1] == null) return;
        _idCurrentGun = _idCurrentGun == 0 ? 1 : 0;
        if (_spawnedWeapon[_idCurrentGun] == null) return;
        SpawnGun(_idCurrentGun);
    }

    private void OffAllGun()
    {
        foreach (var i in _spawnedWeapon.Where(i => i != null))
        {
            _weaponManager.GetWeaponByName(i.Name).gameObject.SetActive(false);
        }
    }

    private void SpawnGun(int idWeapon)
    {
        OffAllGun();
        _currentWeapon = _weaponManager.GetWeaponByName(_spawnedWeapon[idWeapon].Name);
        _currentWeapon.transform.parent = positionWeapon;
        _currentWeapon.transform.localRotation = Quaternion.identity;
        _currentWeapon.Initialize(_spawnedWeapon[idWeapon], ammoParent, _signalBus,
            _upgradeSave.GetWeaponCharacteristics(_spawnedWeapon[idWeapon].Name));
        _currentWeapon.gameObject.SetActive(true);
    }

    private void SetWeapon(WeaponConfiguration weaponConfiguration, int id)
    {
        OffAllGun();
        if (_spawnedWeapon[id] != null)
        {
            _weaponManager.GetWeaponByName(_spawnedWeapon[id].Name).transform.parent = _weaponManager.transform;
        }

        _spawnedWeapon[id] = weaponConfiguration;
        SpawnGun(id);
    }

    [Inject]
    private void Construct(WeaponManager weaponManager, InputHandler inputHandler, SaveDataManager saveDataManager, SignalBus signalBus)
    {
        _signalBus = signalBus;
        _weaponManager = weaponManager;
        _inputHandler = inputHandler;
        _upgradeSave = saveDataManager.UpgradeSave;
        if (string.IsNullOrEmpty(saveDataManager.WeaponSave.SelectedWeaponName) == false)
        {
            var weapon = _weaponManager.GetWeaponConfigurationByWeapon(
                _weaponManager.GetWeaponByName(saveDataManager.WeaponSave.SelectedWeaponName));
            NewWeapon(weapon);
        }
    }

   
}