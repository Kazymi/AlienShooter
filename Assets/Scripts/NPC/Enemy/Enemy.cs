using UnityEngine;

public class Enemy : MonoBehaviour,IDeathInitialize
{
   [SerializeField] private EnemyMove enemyMove;
   [SerializeField] private EnemyHealth enemyHealth;
   [SerializeField] private EnemyDamageDealer enemyDamageDealer;
   [SerializeField] private NPCDropItem dropItem;
   [SerializeField] private Buffer buffer;
   [SerializeField] private OtherEffect deathEffect;
   
   private Factory _factory;
   private SpawnManager _spawnManager;
   
   public void Initialize(EnemyConfiguration enemyConfiguration,Transform playerTransform,Factory parentFactory,DropItems dropItems, SpawnManager spawnManager)
   {
      _factory = parentFactory;
      _spawnManager = spawnManager;
      
      enemyMove.Initialize(playerTransform,enemyConfiguration.Speed);
      enemyHealth.Initialize(enemyConfiguration.HP,this);
      enemyDamageDealer.Initialize(enemyConfiguration.Damage);
      dropItem.Initialize(dropItems,spawnManager);
      buffer?.Initialize(enemyMove,enemyHealth);
   }

   public void DeadInitialize()
   {
      dropItem.Spawn();
      var i = _spawnManager.Spawn(deathEffect);
      i.position = transform.position;
      _factory.Destroy(gameObject);
   }
}
