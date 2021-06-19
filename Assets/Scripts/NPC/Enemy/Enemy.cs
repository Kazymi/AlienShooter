using UnityEngine;

public class Enemy : MonoBehaviour,IDeathInitialize
{
   [SerializeField] private EnemyMove enemyMove;
   [SerializeField] private EnemyHealth enemyHealth;
   [SerializeField] private EnemyDamageDealer enemyDamageDealer;

   private Factory _parentFactory;
   
   // TODO: useless property. In their own scripts use fields. Properties is for outside code
   public Factory Factory => _parentFactory;
   
   // TODO: <***>
   public void Initialize(EnemyConfiguration enemyConfiguration,Transform playerTransform,Factory parentFactory)
   {
      _parentFactory = parentFactory;
      enemyMove.Initialize(playerTransform,enemyConfiguration.Speed);
      enemyHealth.Initialize(enemyConfiguration.HP,this);
      enemyDamageDealer.Initialize(enemyConfiguration.Damage);
   }

   public void DeadInitialize()
   {
      Factory.Destroy(gameObject);
   }
}
