using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider))]
public class PlayerHealth : Damageable
{
   private SignalBus _signalBus;

   [Inject]
   private void Construct(SignalBus signalBus)
   {
      _signalBus = signalBus;
   }
   public override void TakeDamage(float damage)
   {
      base.TakeDamage(damage);
      _signalBus.Fire(new UpdateHeathSignal(_currentHealth/_maxHealth));
   }
}