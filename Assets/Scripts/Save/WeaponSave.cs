
    using System.Collections.Generic;

    public class WeaponSave
    {
        private SaveData _saveData;
        public WeaponSave(SaveData saveData)
        {
            _saveData = saveData;
        }

        public List<string> UnlockedWeapon => _saveData.UnlockedWeapon;
        public string SelectedWeaponName => _saveData.SelectedWeaponName;

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
            foreach (var i in UnlockedWeapon)
            {
                if (i == name) return true;
            }
            return false;
        }
    }
