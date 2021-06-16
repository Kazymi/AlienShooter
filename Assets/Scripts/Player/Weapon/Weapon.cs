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
    
    public void Initialize(WeaponConfiguration gunConfiguration)
    {
        transform.localPosition = Vector3.zero;
        _reloaded = false;
        _lockFire = false;
        InitializeWeapon(gunConfiguration);
        InitializeFactory();
        if(_initialized) return;
        _initialized = true;
        _currentWeaponConfiguration = gunConfiguration.AmmoConfiguration;
        _ammo = _weaponConfiguration.MaxAmmo;
    }
    
    private void Fire()
    {
        if(_lockFire || _reloaded) return;
        _ammo--;
        if (_ammo <= 0)
        { 
            StartCoroutine(Reloaded());
            return;
        }
        GameObject ammo = _factory.Create(positionSpawnAmmo.position);
        ammo.GetComponent<IAmmo>().Initialize(_currentWeaponConfiguration,_factory);
        ammo.transform.position = positionSpawnAmmo.position;
        ammo.transform.rotation = positionSpawnAmmo.rotation;
        StartCoroutine(FireRateTimer());
    }
    
    private void InitializeFactory()
    {
        _factory = new Factory(_weaponConfiguration.AmmoConfiguration.AmmoGameObject,30);
    }

    private void InitializeWeapon(WeaponConfiguration weaponConfiguration)
    {
        _weaponConfiguration = weaponConfiguration;
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
