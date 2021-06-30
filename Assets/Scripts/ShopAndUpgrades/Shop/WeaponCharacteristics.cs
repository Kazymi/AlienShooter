    public class WeaponCharacteristics
    {
        private readonly float _damage;
        private readonly float _fireRate;
        private readonly float _speedReloaded;
        private readonly float _speedAmmo;
        private readonly int _countAmmo;

        public float Damage => _damage / 100;
        public float FireRate => _fireRate / 1;
        public float SpeedReloaded => _speedReloaded / 3;
        public float SpeedAmmo => _speedAmmo / 100;
        public int CountAmmo => _countAmmo;
        
        public WeaponCharacteristics(float damage, float fireRate, float speedReloaded, float speedAmmo, int countAmmo)
        {
            _damage = damage;
            _fireRate = fireRate;
            _speedReloaded = speedReloaded;
            _speedAmmo = speedAmmo;
            _countAmmo = countAmmo;
        }
    }
