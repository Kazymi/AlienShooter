    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class UpgradeShop : MonoBehaviour
    {
        [SerializeField] private Transform positionWeapon;

        private MoneySave _moneySave;
        private WeaponSave _weaponSave;
        private UpgradeSave _upgradeSave;
        private WeaponManager _weaponManager;
        private UpgradeConfiguration _upgradeConfiguration;
        private WeaponCharacteristics _weaponCharacteristics;
        private UpgradePriceList _upgradePriceList;
        private SaveDataManager _saveDataManager;

        public float DamageSliderValue => (float)_weaponCharacteristics.LvlDamage / 5;
        public float AmmoSliderValue => (float)_weaponCharacteristics.LvlCountAmmo / 5;
        public float FireRateSliderValue => (float)_weaponCharacteristics.LvlFireRate / 5;
        public float TimeReloadedSliderValue => (float)_weaponCharacteristics.LvlSpeedReloaded / 5;

        public void Initialize()
        {
            var nameWeapon = _weaponSave.SelectedWeaponName;
            if (string.IsNullOrEmpty(nameWeapon))
            {
                Debug.Log("Weapon not found");
                return;
            }
            var currentWeapon = _weaponManager.GetWeaponByName(nameWeapon);
            var transformWeapon = currentWeapon.transform;
            transformWeapon.parent = positionWeapon;
            transformWeapon.localPosition = Vector3.zero;
            transformWeapon.localRotation = Quaternion.identity;
            transformWeapon.gameObject.SetActive(true);
            _upgradeConfiguration = _weaponManager.GetWeaponConfigurationByWeapon(currentWeapon).UpgradeConfiguration;
            _weaponCharacteristics = _upgradeSave.GetWeaponCharacteristics(nameWeapon);
            _upgradePriceList = _upgradeConfiguration.GetPriceList(_weaponCharacteristics,_moneySave.Money);
        }

        public void AddDamage()
        {
            if (_upgradePriceList.UnlockBuyDamage == false) return;
            _moneySave.RemoveMoney(_upgradePriceList.PriceDamage);
            _upgradeConfiguration.AddDamage(_weaponCharacteristics);
            EndBuy();;
        }

        public UpgradePriceList UpgradePriceList => _upgradePriceList;

        public void ReduceFireRate()
        {
            if (_upgradePriceList.UnlockBuyReduceFireRate == false) return;
            _moneySave.RemoveMoney(_upgradePriceList.PriceReduceFireRate);
            _upgradeConfiguration.ReduceFireRate(_weaponCharacteristics);
            EndBuy();
        }

        public void AddAmmo()
        {
            if (_upgradePriceList.UnlockBuyAmmo == false) return;
            _moneySave.RemoveMoney(_upgradePriceList.PriceAmmo);
            _upgradeConfiguration.AddAmmo(_weaponCharacteristics);
            EndBuy();
        }

        public void ReduceTimeReloaded()
        {
            if (_upgradePriceList.UnlockBuyReduceTimeReloaded == false) return;
            _moneySave.RemoveMoney(_upgradePriceList.PriceReduceTimeReloaded);
            _upgradeConfiguration.ReduceTimeReloaded(_weaponCharacteristics);
            EndBuy();
        }

        public bool WeaponSelected()
        {
            return string.IsNullOrEmpty(_weaponSave.SelectedWeaponName) == false;
        }
        private void EndBuy()
        {
            _upgradePriceList = _upgradeConfiguration.GetPriceList(_weaponCharacteristics, _moneySave.Money);
            _saveDataManager.Save();
        }
        [Inject]
        private void Construct(SaveDataManager saveDataManager,WeaponManager weaponManager)
        {
            _weaponManager = weaponManager;
            _moneySave = saveDataManager.MoneySave;
            _weaponSave = saveDataManager.WeaponSave;
            _upgradeSave = saveDataManager.UpgradeSave;
            _saveDataManager = saveDataManager;
        }
    }