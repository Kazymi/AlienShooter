using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class WeaponPlayerTrigger : MonoBehaviour
{
    [SerializeField] private WeaponControl weaponControl;
    private void OnTriggerEnter(Collider other)
    {
        var i = other.GetComponent<WeaponSpawn>();
        if (i!=null)
        {
            weaponControl.NewWeapon(i.WeaponConfiguration);
            i.Destroy();
        }
    }
}
