using UnityEngine;
public class BuffFireDamage : Effect
{
    private float _damage;
    public override void EffectOnTick()
    {
        _damageable.TakeDamage(_damage*Time.deltaTime);
    }

    public BuffFireDamage(IChangeSpeed changeSpeed, Damageable damageable, float timerEffect, float damage) : base(changeSpeed, damageable, timerEffect)
    {
        _damage = damage;
    }
}