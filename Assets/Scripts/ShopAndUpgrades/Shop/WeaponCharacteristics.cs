    public class WeaponCharacteristics
    {
        private readonly string _name;
        private readonly float _damage;
        private readonly float _fireRate;
        private readonly float _speedReloaded;
        private readonly float _speedAmmo;
        private readonly int _countAmmo;

        public string Name => _name;
        public float Damage => _damage;
        public float FireRate => _fireRate;
        public float SpeedReloaded => _speedReloaded;
        public float SpeedAmmo => _speedAmmo;
        public float CountAmmo => _countAmmo;
        
        public WeaponCharacteristics(float damage, float fireRate, float speedReloaded, float speedAmmo, int countAmmo,string name)
        {
            _name = name;
            _damage = damage;
            _fireRate = fireRate;
            _speedReloaded = speedReloaded;
            _speedAmmo = speedAmmo;
            _countAmmo = countAmmo;
        }
    }
