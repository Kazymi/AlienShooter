using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyHealth : MonoBehaviour,IDamageable
{
    private float _currentHealth;
    private Enemy _enemy;

    public void Initialize(float health, Enemy enemy)
    {
        _currentHealth = health;
        _enemy = enemy;
    }
    
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0) Dead();
    }

    public void Dead()
    {
        _enemy.DeadInitialize();
    }
}
