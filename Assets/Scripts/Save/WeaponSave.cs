using System.Collections.Generic;

public class WeaponSave
{
    private readonly SaveData _saveData;

    public List<string> UnlockedWeapons => _saveData.UnlockedWeapon;
    public string SelectedWeaponName => _saveData.SelectedWeaponName;

    public WeaponSave(SaveData saveData)
    {
        _saveData = saveData;
    }

    public void NewSelectedWeapon(string name)
    {
        _saveData.SelectedWeaponName = name;
    }

    public void UnlockNewWeapon(string name)
    {
        _saveData.UnlockedWeapon.Add(name);
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