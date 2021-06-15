using System.Collections;
using UnityEditor;
using UnityEngine;

public abstract class WeaponControlFire : MonoBehaviour
{
    [SerializeField] protected Transform positionSpawnAmmo;
    
    protected Factory _factory;
    protected WeaponConfiguration _weaponConfiguration;
    protected bool _lockFire;
    protected bool _reloaded;
    protected float _ammo;
    
    public Factory Factory { get => _factory; set => _factory = value; }
    
    public virtual void Fire()
    {
        
    }

    protected virtual IEnumerator Reloaded()
    {
        _reloaded = true;
        yield return new WaitForSeconds(_weaponConfiguration.TimeReloaded);
        _ammo = _weaponConfiguration.MaxAmmo;
        _reloaded = false;
    }

    public virtual void InitializeFactory()
    {
        _factory = new Factory(_weaponConfiguration.AmmoConfiguration.AmmoGameObject,30);
    }

    public virtual void InitializeWeapon(WeaponConfiguration weaponConfiguration)
    {
        _weaponConfiguration = weaponConfiguration;
    }

    protected IEnumerator FireRateTimer()
    {
        _lockFire = true;
        yield return new WaitForSeconds(_weaponConfiguration.FireRate);
        _lockFire = false;
    }
}
