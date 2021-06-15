using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon")]
public class WeaponConfiguration : ScriptableObject
{
    [SerializeField] private string nameGun;
    [SerializeField] private float damage;
    [SerializeField] private int maxAmmo;
    [Range(0,1)] [SerializeField] private float fireRate;
    [Range(0,3)] [SerializeField] private float timeReloaded;
    [SerializeField] private Weapon weaponGameObject;
    [SerializeField] private AmmoConfiguration ammoConfiguration;
    
    public string Name => nameGun;
    public Weapon WeaponGameObject => weaponGameObject;
    public AmmoConfiguration AmmoConfiguration => ammoConfiguration;
    public float FireRate => fireRate;
    public float TimeReloaded => timeReloaded;
    public int MaxAmmo => maxAmmo;
}
