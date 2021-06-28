using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Damageable : MonoBehaviour
{
   protected float _currentHealth;
   protected float _maxHealth;
   private IDeathInitialize _deathInitialize;
   private bool _invincible;
   private bool _alive;

   public bool Invincible
   {
      set => _invincible = value;
   }
   public void Initialize(float health, IDeathInitialize deathInitialize)
   {
      _maxHealth = health;
      _alive = false;
      _invincible = false;
      _currentHealth = health;
      _deathInitialize = deathInitialize;
   }
    
   public virtual void TakeDamage(float damage)
   {
      if(_invincible || _alive) return;
      _currentHealth -= damage;
      if(_currentHealth <= 0) Dead();
   }

   public virtual void Dead()
   {
      _alive = true;
      _deathInitialize.DeadInitialize();
   }
}
