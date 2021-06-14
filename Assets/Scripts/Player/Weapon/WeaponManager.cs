using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<GunConfiguration> gunConfigurations;

    public GunConfiguration GetGunByName(string name)
    {
        foreach(var i in gunConfigurations)
        {
            
        }
        return gunConfigurations[0];
    }
}
