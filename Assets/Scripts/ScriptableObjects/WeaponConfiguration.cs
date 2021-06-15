using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon")]
public class WeaponConfiguration : ScriptableObject
{
    [SerializeField] private string nameGun;
    [SerializeField] private float damage;
    [SerializeField] private int maxammo;
    [Range(0,1)] [SerializeField] private float fireRate;
    [Range(0,3)] [SerializeField] private float timeReloded;
    [SerializeField] private GameObject weaponGameObject;
    [SerializeField] private AmmoConfiguration ammoConfiguration;
    public string Name => nameGun;
    public GameObject WeaponGameObject => weaponGameObject;
    public AmmoConfiguration AmmoConfiguration => ammoConfiguration;
    public float FireRate => fireRate;
    public float TimeReloded => timeReloded;
    public int MapAmmo => maxammo;
}
