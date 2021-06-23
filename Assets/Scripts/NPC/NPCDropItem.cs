using System.Collections.Generic;
using UnityEngine;

public class NPCDropItem : MonoBehaviour
{
    [SerializeField] private int chanceDrop;

    private DropItems _dropItems;
    private SpawnManager _spawnManager;
    
    public void Initialize(DropItems dropItems,SpawnManager spawnManager)
    {
        _dropItems = dropItems;
        _spawnManager = spawnManager;
    }

    public void Spawn()
    {
        if (Random.Range(0, 100) >= chanceDrop) return;
        Transform itemTransform;
        if (Random.Range(0, 2) == 1)
        {
            itemTransform = _spawnManager.GetEffect(
                _dropItems.EffectSystems[Random.Range(0, _dropItems.EffectSystems.Count)]);
        }
        else
        {
            itemTransform = _spawnManager.GetWeapon(
                _dropItems.WeaponConfigurations[Random.Range(0, _dropItems.WeaponConfigurations.Count)]);
        }
        itemTransform.position = transform.position;
    }
}