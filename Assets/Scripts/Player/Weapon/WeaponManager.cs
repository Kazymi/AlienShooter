using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponConfiguration> weaponConfigurations;
    
    private Dictionary<string, Weapon> _weapons = new Dictionary<string, Weapon>();

    private void Start()
    {
       foreach(var i in weaponConfigurations)
       {
           NewWeapon(i.WeaponGameObject, i.Name);
       }
    }
    
    public Weapon GetWeaponByName(string name)
    {
        return _weapons[name];
    }
    
    private void NewWeapon(Weapon weapon,string name)
    {
        var newGun = Instantiate(weapon,transform);
        newGun.gameObject.SetActive(false);
        _weapons.Add(name, newGun);
    }
}
