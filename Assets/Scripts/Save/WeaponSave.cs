using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponSave
{

    [SerializeField] private string _selectedWeaponName;
    [SerializeField] private List<string> _unlockWeapons = new List<string>();

    public List<string> UnlockedWeapons
    {
        get => _unlockWeapons;
        set => _unlockWeapons = value;
    }

    public string SelectedWeaponName
    {
        get => _selectedWeaponName;
        set => _selectedWeaponName = value;
    }

    public void NewSelectedWeapon(string name)
    {
        _selectedWeaponName = name;
    }

    public void UnlockNewWeapon(string name)
    {
        _unlockWeapons.Add(name);
    }

    public bool CheckBoughtWeapon(string name)
    {
        foreach (var unlockedWeapon in UnlockedWeapons)
        {
            if (unlockedWeapon == name)
            {
                return true;
            }
        }

        return false;
    }
}