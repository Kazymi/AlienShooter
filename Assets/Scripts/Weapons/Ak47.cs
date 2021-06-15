using System.Collections;
using UnityEngine;

public class Ak47 : MonoBehaviour,IWeapon
{
    [SerializeField] private Transform positionSpawnAmmo;
    
    private Factory _factory;
    private WeaponConfiguration _weaponConfiguration;
    private bool _lockFire;
    private bool _reloded;
    private float _ammo;
    
    public Factory Factory { get => _factory; set => _factory = value; }
    
    public void Fire()
    {
        if(_lockFire || _reloded) return;
        _ammo--;
        if (_ammo == 0) StartCoroutine(Reloded());
        _factory.Create(positionSpawnAmmo.position);
        StartCoroutine(FireRateTimer());
    }

    public IEnumerator Reloded()
    {
        _reloded = true;
        yield return new WaitForSeconds(_weaponConfiguration.TimeReloded);
        _ammo = _weaponConfiguration.MapAmmo;
        _reloded = false;
    }

    public void InitializeFactory()
    {
        _factory = new Factory();
        _factory.InitializeFactory(_weaponConfiguration.AmmoConfiguration.AmmpGameObject,30);
    }

    public void InitializeWeapon(WeaponConfiguration weaponConfiguration)
    {
        _weaponConfiguration = weaponConfiguration;
    }

    IEnumerator FireRateTimer()
    {
        _lockFire = true;
        yield return new WaitForSeconds(_weaponConfiguration.FireRate);
        _lockFire = false;
    }
}
