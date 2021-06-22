using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WeaponSpawn : MonoBehaviour
{
    [SerializeField] private WeaponConfiguration weaponConfiguration;

    public WeaponConfiguration WeaponConfiguration => weaponConfiguration;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
