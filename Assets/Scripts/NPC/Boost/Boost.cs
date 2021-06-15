using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private WeaponConfiguration weaponConfiguration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerTrigger>())
        {
            other.GetComponent<PlayerTrigger>().Player.WeaponControl.NewWeapon(weaponConfiguration);
            Destroy(gameObject);
        }
    }
}
