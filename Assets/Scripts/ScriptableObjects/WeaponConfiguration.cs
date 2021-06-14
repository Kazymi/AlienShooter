using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon")]
public class WeaponConfiguration : Factory
{
    [SerializeField] private string nameGun;
    [SerializeField] private float damage;
    [SerializeField] private float maxammo;
    [Range(0,1)] [SerializeField] private float fireRate;

    private WeaponManager _weaponManager;

    [Inject]
    private void Construct(WeaponManager weaponManager)
    {
        _weaponManager = weaponManager;
    }

    public override void Create(Vector3 positionSpawn)
    {
        CreateNewGun(positionSpawn);
    }

    public override void Create(Vector3 positionSpawn, Quaternion rotation)
    {
        CreateNewGun(positionSpawn).transform.rotation = rotation;
    }

    private GameObject CreateNewGun(Vector3 positionSpawn)
    {
        var newObject = Pool.Pull();
        newObject.GetComponent<Weapon>().Initialize(Pool, this);
        newObject.transform.position = positionSpawn;
        _weaponManager.NewWeapon(newObject, nameGun);
        return newObject;
    }
    public override void InitializeFactory()
    {
        pool = new Pool(SpawnElement, 0);
        Create(Vector3.zero);
    }
}
