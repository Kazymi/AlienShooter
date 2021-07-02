
    public class UpgradePriceList
    {
        private int _priceDamage;
        private bool _unlockBuyDamage;
        private int _priceAmmo;
        private bool _unlockBuyAmmo;
        private int _priceReduceFireRate;
        private bool _unlockBuyReduceFireRate;
        private int _priceReduceTimeReloaded;
        private bool _unlockBuyReduceTimeReloaded;

        public int PriceDamage => _priceDamage;

        public bool UnlockBuyDamage => _unlockBuyDamage;

        public int PriceAmmo => _priceAmmo;

        public bool UnlockBuyAmmo => _unlockBuyAmmo;

        public int PriceReduceFireRate => _priceReduceFireRate;

        public bool UnlockBuyReduceFireRate => _unlockBuyReduceFireRate;

        public int PriceReduceTimeReloaded => _priceReduceTimeReloaded;

        public bool UnlockBuyReduceTimeReloaded => _unlockBuyReduceTimeReloaded;


        public UpgradePriceList(int priceDamage, int priceAmmo, int priceReduceFireRate, int priceReduceTimeReloaded,int playerMoney,WeaponCharacteristics weaponCharacteristics)
        {
            _priceDamage = priceDamage;
            _unlockBuyDamage = priceDamage <= playerMoney && weaponCharacteristics.LvlDamage <= 5;
            
            _priceAmmo = priceAmmo;
            _unlockBuyAmmo = priceAmmo <= playerMoney && weaponCharacteristics.LvlCountAmmo <= 5;
            
            _priceReduceFireRate = priceReduceFireRate;
            _unlockBuyReduceFireRate = priceReduceFireRate <= playerMoney && weaponCharacteristics.LvlFireRate <= 5;
            
            _priceReduceTimeReloaded = priceReduceTimeReloaded;
            _unlockBuyReduceTimeReloaded = priceReduceTimeReloaded <= playerMoney && weaponCharacteristics.LvlSpeedReloaded <= 5;
        }
    }
