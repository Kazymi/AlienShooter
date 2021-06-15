using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] private WeaponConfiguration startWeapon;
    [SerializeField] private Transform positionWeapon;

    private Weapon _currentWeapon;
    private List<WeaponConfiguration> _spawnedWeapon = new List<WeaponConfiguration>(){null,null};
    private WeaponManager _weaponManager;
    private int _idCurrentGun;

    private void Start()
    {
        if (startWeapon != null)
        {
            NewWeapon(startWeapon);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) NextWeapon();
    }

    private void NextWeapon()
    {
        if(_spawnedWeapon[0]==null && _spawnedWeapon[1] == null) return;
        _idCurrentGun = _idCurrentGun == 0 ? 1 : 0;
        if(_spawnedWeapon[_idCurrentGun] == null) return;
        SpawnGun(_idCurrentGun);
    }
    [Inject]
    private void Construct(WeaponManager weaponManager)
    {
        _weaponManager = weaponManager;
    }

    private void OffAllGun()
    {
        foreach (var i in _spawnedWeapon)
        {
            if(i!=null)
            _weaponManager.GetWeaponByName(i.Name).gameObject.SetActive(false);
        }
    }
    private void SpawnGun(int idWeapon)
    {
        OffAllGun();
        _currentWeapon = _weaponManager.GetWeaponByName(_spawnedWeapon[idWeapon].Name);
        _currentWeapon.transform.parent = positionWeapon;
        // _currentWeapon.Initialize(_spawnedWeapon[idWeapon]);
        _currentWeapon.gameObject.SetActive(true);
    }

    public void NewWeapon(WeaponConfiguration weaponConfiguration)
    {
        if (_spawnedWeapon[0] == null)
        {
            SetWeapon(weaponConfiguration, 0);
            return;
        }
        if (_spawnedWeapon[1] == null)
        {
            SetWeapon(weaponConfiguration, 1);
            return;
        }
        SetWeapon(weaponConfiguration, _idCurrentGun);
    }

    private void SetWeapon(WeaponConfiguration weaponConfiguration, int id)
    {
        OffAllGun();
        _spawnedWeapon[id] = weaponConfiguration;
        SpawnGun(id);
    }
}
