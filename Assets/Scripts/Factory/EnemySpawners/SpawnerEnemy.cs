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
    [SerializeField] private List<SpawnPosition> _spawnPositions;

    private Factory _factory;
    private SpawnManager _spawnManager;
    private SignalBus _signalBus;
    
    private void Start()
    {
        _factory = new Factory(enemyConfiguration.EnemyGameObject,countEnemy,transform);
        StartCoroutine(Spawn());
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(StopAllCoroutines);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(StopAllCoroutines);
    }

    private void SpawnEnemy()
    {
       var spawnPositionID = Random.Range(0, _spawnPositions.Count);
       var randomRadiusX = _spawnPositions[spawnPositionID].MaxX / 2;
       var randomRadiusZ = _spawnPositions[spawnPositionID].MaxZ / 2;
       
       var posX = Random.Range(-randomRadiusX, randomRadiusX) +
                  _spawnPositions[spawnPositionID].gameObject.transform.position.x;
       var posZ = Random.Range(-randomRadiusZ, randomRadiusZ) +
                  _spawnPositions[spawnPositionID].gameObject.transform.position.z;
       
       var positionSpawn = new Vector3(posX, 0, posZ);
       _factory.Create(positionSpawn).GetComponent<Enemy>().Initialize(enemyConfiguration,
           playerTranform,
           _factory,
           dropItems,
           _spawnManager, 
           _signalBus
           );
    }

    [Inject]
    private void Construct(SpawnManager spawnManager,SignalBus signalBus)
    {
        _spawnManager = spawnManager;
        _signalBus = signalBus;
    }
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            SpawnEnemy();
        }
    }
}
