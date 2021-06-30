using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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

// TODO:
/*
 // SaveDataManager is the only class that stores this data
public class SaveData
{
    private _moneyData;
    private _upgradeData;
    private _weaponData;
}


public class SaveDataManager
{
    private SaveData;

    public MoneyData {get;}
    ...
    ...
}
*/