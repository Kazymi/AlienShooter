using System.Collections;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform positionSpawnAmmo;

    private InputHandler _inputHandler;
    private Factory _factory;
    private WeaponConfiguration _weaponConfiguration;
    private AmmoConfiguration _currentWeaponConfiguration;
    private bool _initialized;
    private bool _lockFire;
    private bool _reloaded;
    private float _ammo;
    private void Update()
    {
        if(_inputHandler.Fire) Fire();
    }
    
    private void Fire()
    {
        if(_lockFire || _reloaded) return;
        _ammo--;
        if (_ammo == 0) StartCoroutine(Reloaded());
        GameObject ammo = _factory.Create(positionSpawnAmmo.position);
        ammo.GetComponent<IAmmo>().Initialize(_currentWeaponConfiguration,_factory);
        ammo.transform.position = positionSpawnAmmo.position;
        ammo.transform.rotation = positionSpawnAmmo.rotation;
        StartCoroutine(FireRateTimer());
    }
    public void Initialize(WeaponConfiguration gunConfiguration)
    {
        transform.localPosition = Vector3.zero;
        InitializeWeapon(gunConfiguration);
        InitializeFactory();
        if(_initialized) return;
        FirstInitialize(gunConfiguration);
    }

    private void FirstInitialize(WeaponConfiguration gunConfiguration)
    {
        _initialized = true;
        _currentWeaponConfiguration = gunConfiguration.AmmoConfiguration;
    }
    private void InitializeFactory()
    {
        _factory = new Factory(_weaponConfiguration.AmmoConfiguration.AmmoGameObject,30);
    }

    private void InitializeWeapon(WeaponConfiguration weaponConfiguration)
    {
        _weaponConfiguration = weaponConfiguration;
        _ammo = _weaponConfiguration.MaxAmmo;
    }

    private IEnumerator FireRateTimer()
    {
        _lockFire = true;
        yield return new WaitForSeconds(_weaponConfiguration.FireRate);
        _lockFire = false;
    }
    private IEnumerator Reloaded()
    {
        _reloaded = true;
        yield return new WaitForSeconds(_weaponConfiguration.TimeReloaded);
        _ammo = _weaponConfiguration.MaxAmmo;
        _reloaded = false;
    }
[Inject]
    private void Construct(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }
}
