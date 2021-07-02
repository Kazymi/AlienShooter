using UnityEngine;

[CreateAssetMenu(fileName = "New upgrade config", menuName = "UpgradeConfiguration")]
public class UpgradeConfiguration : ScriptableObject
{
    [SerializeField] private int addDamage;
    [SerializeField] private int priceDamage;
    [SerializeField] private int addAmmo;
    [SerializeField] private int priceAmmo;
    [SerializeField] private float reduceFireRate;
    [SerializeField] private int priceFireRate;
    [SerializeField] private float reduceTimeReloaded;
    [SerializeField] private int priceTimeReloaded;

    public void AddDamage(WeaponCharacteristics weaponCharacteristics)
    {
        weaponCharacteristics.Damage += addDamage;
        weaponCharacteristics.LvlDamage++;
    }

    public void AddAmmo(WeaponCharacteristics weaponCharacteristics)
    {
        weaponCharacteristics.CountAmmo += addAmmo;
        weaponCharacteristics.LvlCountAmmo++;
    }

    public void ReduceFireRate(WeaponCharacteristics weaponCharacteristics)
    {
        weaponCharacteristics.FireRate -= reduceFireRate;
        weaponCharacteristics.LvlFireRate++;
    }

    public void ReduceTimeReloaded(WeaponCharacteristics weaponCharacteristics)
    {
        weaponCharacteristics.SpeedReloaded -= reduceTimeReloaded;
        weaponCharacteristics.LvlSpeedReloaded++;
    }

    public UpgradePriceList GetPriceList(WeaponCharacteristics weaponCharacteristics,int money)
    {
        var i = new UpgradePriceList(
            weaponCharacteristics.LvlDamage == 0 ? priceDamage : priceDamage * weaponCharacteristics.LvlDamage,
            weaponCharacteristics.LvlCountAmmo == 0 ? priceAmmo : priceAmmo * weaponCharacteristics.LvlCountAmmo,
            weaponCharacteristics.LvlFireRate == 0 ? priceFireRate : priceFireRate * weaponCharacteristics.LvlFireRate,
            weaponCharacteristics.LvlSpeedReloaded == 0
                ? priceTimeReloaded
                : priceTimeReloaded * weaponCharacteristics.LvlSpeedReloaded,
            money,
            weaponCharacteristics
        );
        return i;
    }
}