using TMPro;
using UnityEngine;
using Zenject;

public class  StatisticUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ammoText;

    private WeaponControl _weaponControl;

    [Inject]
    public void Construct(Player player)
    {
        _weaponControl = player.WeaponControl;
    }

    public void UpdateAmmo()
    {
        var currentWeapon = _weaponControl.CurrentWeapon;
        if (currentWeapon != null)
        {
            ammoText.text = currentWeapon.Ammo.ToString();
        }
    }
}
