using UnityEngine;

public class Enemy : MonoBehaviour,IDeathInitialize
{
   [SerializeField] private EnemyMove enemyMove;
   [SerializeField] private EnemyHealth enemyHealth;
   [SerializeField] private EnemyDamageDealer enemyDamageDealer;
   [SerializeField] private NPCDropItem dropItem;

   private Factory _factory;

   public void Initialize(EnemyConfiguration enemyConfiguration,Transform playerTransform,Factory parentFactory,DropItems dropItems, SpawnManager spawnManager)
   {
      _factory = parentFactory;
      enemyMove.Initialize(playerTransform,enemyConfiguration.Speed);
      enemyHealth.Initialize(enemyConfiguration.HP,this);
      enemyDamageDealer.Initialize(enemyConfiguration.Damage);
      dropItem.Initialize(dropItems,spawnManager);
   }

   public void DeadInitialize()
   {
      dropItem.Spawn();
      _factory.Destroy(gameObject);
   }
}
