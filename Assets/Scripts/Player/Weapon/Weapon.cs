using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void Initialize(WeaponConfiguration gunConfiguration)
    {
        transform.localPosition = Vector3.zero;
        var weapon = GetComponent<WeaponControlFire>();
        if(weapon == null) Debug.LogError("IWeapon == null");
        weapon.InitializeWeapon(gunConfiguration);
        weapon.InitializeFactory();
    }
}
