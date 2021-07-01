using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    [SerializeField] private MoneySave _moneySave = new MoneySave();
    [SerializeField] private WeaponSave _weaponSave =  new WeaponSave();
    [SerializeField] private UpgradeSave _upgradeSave = new UpgradeSave();

    public MoneySave MoneySave
    {
        get => _moneySave;
        set => _moneySave = value;
    }

    public WeaponSave WeaponSave
    {
        get => _weaponSave;
        set => _weaponSave = value;
    }

    public UpgradeSave UpgradeSave
    {
        get => _upgradeSave;
        set => _upgradeSave = value;
    }

}