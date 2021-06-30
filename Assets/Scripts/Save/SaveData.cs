using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    [SerializeField] private int money;
    [SerializeField] private List<string> unlockedWeapon = new List<string>();
    [SerializeField] private string selectedWeaponName;
    [SerializeField] private List<WeaponCharacteristics> weaponCharacteristicsList = new List<WeaponCharacteristics>();

    public List<WeaponCharacteristics> WeaponCharacteristicsList
    {
        get => weaponCharacteristicsList;
        set => weaponCharacteristicsList = value;
    }
    public int Money
    {
        get => money;
        set => money = value;
    }

    public List<string> UnlockedWeapon
    {
        get => unlockedWeapon;
        set => unlockedWeapon = value;
    }

    public string SelectedWeaponName
    {
        get => selectedWeaponName;
        set => selectedWeaponName = value;
    }
}