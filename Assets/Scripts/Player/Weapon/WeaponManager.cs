using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponConfiguration> WeaponConfigurations;

    private Dictionary<string,GameObject> spawnedWeaponsGameObjects = new Dictionary<string, GameObject>();

    private void Start()
    {
       foreach(var i in WeaponConfigurations)
        {
            i.InitializeFactory();
        }
    }

    public void NewWeapon(GameObject weapon,string name)
    {
        if(!spawnedWeaponsGameObjects.ContainsKey(name))
        spawnedWeaponsGameObjects.Add(name, weapon);
    }
    private void Update()
    {
        Debug.Log(spawnedWeaponsGameObjects.Count);
    }
}
