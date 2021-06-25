using UnityEngine;
public class EffectFireDamage : Effect
{
    private float _damage;
    private Damageable _damageable;

    protected override void EffectOnTick()
    {
        _damageable.TakeDamage(_damage*Time.deltaTime);
    }

    public EffectFireDamage(Damageable damageable, float timerEffect, float damage) : base(timerEffect)
    {
        _damage = damage;
        _damageable = damageable;
    }
}