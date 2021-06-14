using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Pool _pool;
    private WeaponConfiguration _gunConfiguration;

    public Pool Pool => Pool;

    public void Initialize(Pool pool,WeaponConfiguration gunConfiguration)
    {
        _gunConfiguration = gunConfiguration;
        _pool = pool;
    }
}
