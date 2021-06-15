using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponConfiguration> weaponConfigurations;

    private Dictionary<string, GameObject> _weapons = new Dictionary<string, GameObject>();
    private void Start()
    {
       foreach(var i in weaponConfigurations)
        {
            NewWeapon(i.WeaponGameObject, i.Name);
        }
    }
    private void NewWeapon(GameObject weapon,string name)
    {
        GameObject newGun = Instantiate(weapon);
        newGun.SetActive(false);
        _weapons.Add(name, newGun);
    }

    public GameObject GetWeaponByName(string name)
    {
        return _weapons[name];
    }
}
