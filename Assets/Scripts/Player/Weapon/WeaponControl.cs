using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] private WeaponConfiguration startWeapon;
    [SerializeField] private Transform positionWeapon;

    private WeaponConfiguration _currentWeapon;
    private List<Weapon> _spawnedWeapon = new List<Weapon>() { null,null };
    private WeaponManager _weaponManager;
    private int _idCurrentGun;

    private void Start()
    {
        if(startWeapon != null)
        {
            SpawnGun(startWeapon);
        }
    }

    [Inject]
    private void Construct(WeaponManager weaponManager)
    {
        _weaponManager = weaponManager;
    }

    private void SpawnGun(WeaponConfiguration spawnGunConfiguration)
    {
        foreach(var i in _spawnedWeapon)
        {
            if(i != null)
            i.Pool.Push(i.gameObject);
        }
        _currentWeapon = spawnGunConfiguration;
        _currentWeapon.Create(positionWeapon.position);

    }
}
