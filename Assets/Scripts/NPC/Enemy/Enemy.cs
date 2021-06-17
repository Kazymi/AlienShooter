using UnityEngine;

public class Enemy : MonoBehaviour,IDeathInitialize
{
   [SerializeField] private EnemyMove enemyMove;
   [SerializeField] private EnemyHealth enemyHealth;
   [SerializeField] private EnemyDamageDealer enemyDamageDealer;

   private Factory _parentFactory;
   
   public Factory Factory => _parentFactory;
   
   public void Initialize(EnemyConfiguration enemyConfiguration,Transform playerTranform,Factory parentFactory)
   {
      _parentFactory = parentFactory;
      enemyMove.Initialize(playerTranform,enemyConfiguration.Speed);
      enemyHealth.Initialize(enemyConfiguration.HP,this);
      enemyDamageDealer.Initialize(enemyConfiguration.Damage);
   }

   public void DeadInitialize()
   {
      Factory.Destroy(gameObject);
   }
}
