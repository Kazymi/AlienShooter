using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class WeaponCharacteristics
{
    [SerializeField] private string name;
    [SerializeField] private float damage;
    [SerializeField] private int lvlDamage;
    [SerializeField] private float fireRate;
    [SerializeField] private int lvlFireRate;
    [SerializeField] private float speedReloaded;
    [SerializeField] private int lvlSpeedReloaded;
    [SerializeField] private float speedAmmo;
    [SerializeField] private int lvlCountAmmo;
    [SerializeField] private int countAmmo;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public int LvlDamage
    {
        get => lvlDamage;
        set => lvlDamage = value;
    }

    public float FireRate
    {
        get => fireRate;
        set => fireRate = value;
    }

    public int LvlFireRate
    {
        get => lvlFireRate;
        set => lvlFireRate = value;
    }

    public float SpeedReloaded
    {
        get => speedReloaded;
        set => speedReloaded = value;
    }

    public int LvlSpeedReloaded
    {
        get => lvlSpeedReloaded;
        set => lvlSpeedReloaded = value;
    }

    public float SpeedAmmo
    {
        get => speedAmmo;
        set => speedAmmo = value;
    }

    public int LvlCountAmmo
    {
        get => lvlCountAmmo;
        set => lvlCountAmmo = value;
    }

    public int CountAmmo
    {
        get => countAmmo;
        set => countAmmo = value;
    }

    public WeaponCharacteristics(float damage, float fireRate, float speedReloaded, float speedAmmo, int countAmmo, string name)
    {
        this.name = name;
        this.damage = damage;
        this.fireRate = fireRate;
        this.speedReloaded = speedReloaded;
        this.speedAmmo = speedAmmo;
        this.countAmmo = countAmmo;
    }
}