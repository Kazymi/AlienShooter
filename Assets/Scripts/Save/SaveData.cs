using System.Collections.Generic;

public class SaveData
{
    public int Money { get; set; }
    public List<string> UnlockedWeapon { get; } = new List<string>();
    public string SelectedWeaponName { get; set; }
}