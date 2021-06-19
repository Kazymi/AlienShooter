using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpider : MonoBehaviour
{
    [SerializeField] private EnemyConfiguration enemyConfiguration;
    [SerializeField] private Transform playerTranform;
    
    private Factory _factory;
    private void Start()
    {
        // TODO: move hardcoded value
        _factory = new Factory(enemyConfiguration.EnemyGameObject,10);
        StartCoroutine(Spawn());
    }
    private void SpawnEnemy()
    {
        _factory.Create(Vector3.zero).GetComponent<Enemy>().Initialize(enemyConfiguration,playerTranform,_factory);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            // TODO: move hardcoded value
            yield return new WaitForSeconds(1f);
            SpawnEnemy();
        }
    }
}
