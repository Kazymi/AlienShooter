﻿using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerHealth : Damageable
{
   [SerializeField] private HealthBar _healthBar;

   public override void TakeDamage(float damage)
   {
      base.TakeDamage(damage);
      _healthBar?.UpdateHeal(_currentHealth/_maxHealth);
   }
}