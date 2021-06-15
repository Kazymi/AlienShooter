using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void Initialize(WeaponConfiguration gunConfiguration)
    {
        var weapon = GetComponent<IWeapon>();
        if(weapon == null) Debug.LogError("IWeapon == null");
        weapon.InitializeFactory();
        weapon.InitializeWeapon(gunConfiguration);
    }
}
