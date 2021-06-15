using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    Factory Factory { get; set; }
    
    void Fire();
    IEnumerator Reloded();
    void InitializeFactory();
    void InitializeWeapon(WeaponConfiguration weaponConfiguration);
}
