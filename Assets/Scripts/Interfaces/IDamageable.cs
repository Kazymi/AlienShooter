using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Damageable : MonoBehaviour
{
   private float _currentHealth;
   private IDeathInitialize _deathInitialize;

   public void Initialize(float health, IDeathInitialize deathInitialize)
   {
      _currentHealth = health;
      _deathInitialize = deathInitialize;
   }
    
   public virtual void TakeDamage(float damage)
   {
      _currentHealth -= damage;
      if(_currentHealth <= 0) Dead();
   }

   public virtual void Dead()
   {
      _deathInitialize.DeadInitialize();
   }
}
