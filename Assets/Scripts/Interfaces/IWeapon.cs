using System.Collections;

public interface IWeapon
{
    Factory Factory { get; set; }
    
    void Fire();
    IEnumerator Reloaded();
    void InitializeFactory();
    void InitializeWeapon(WeaponConfiguration weaponConfiguration);
}
