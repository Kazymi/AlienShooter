using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private WeaponConfiguration weaponConfiguration;

    // TODO: let's invert this. Player should pick up weapons and boosts, items shouldn't have access to player components
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerTrigger>())
        {
            other.GetComponent<PlayerTrigger>().Player.WeaponControl.NewWeapon(weaponConfiguration);
            Destroy(gameObject);
        }
    }
}
