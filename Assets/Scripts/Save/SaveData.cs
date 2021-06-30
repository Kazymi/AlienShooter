using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    [SerializeField] private int money;
    [SerializeField] private List<string> unlockedWeapon = new List<string>();
    [SerializeField] private string selectedWeaponName;

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