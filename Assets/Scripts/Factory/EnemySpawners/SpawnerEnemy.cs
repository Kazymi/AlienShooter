using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private EnemyConfiguration enemyConfiguration;
    [SerializeField] private Transform playerTranform;
    [SerializeField] private int countEnemy;
    [SerializeField] private float spawnTimer = 1f;
    [SerializeField] private DropItems dropItems;
    
    private Factory _factory;
    private SpawnManager _spawnManager;
    private void Start()
    {
        _factory = new Factory(enemyConfiguration.EnemyGameObject,countEnemy);
        StartCoroutine(Spawn());
    }
    private void SpawnEnemy()
    {
        _factory.Create(Vector3.zero).GetComponent<Enemy>().Initialize(enemyConfiguration,playerTranform,_factory,dropItems,_spawnManager);
    }

    [Inject]
    private void Construct(SpawnManager spawnManager)
    {
        _spawnManager = spawnManager;
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            SpawnEnemy();
        }
    }
}
