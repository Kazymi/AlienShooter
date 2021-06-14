using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConfiguration : ScriptableObject
{
    [SerializeField] private string nameGun;
    [SerializeField] private float damage;
    [SerializeField] private float maxammo;
    [Range(0,1)] [SerializeField] private float fireRate;
    [SerializeField] private GameObject gunGameObject;
}
