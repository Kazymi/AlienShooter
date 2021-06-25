public class EffectInvincible : Effect
{
    private Damageable _damageable;
        public EffectInvincible(float timerEffect,Damageable damageable) : base(timerEffect)
        {
            _damageable = damageable;
            ActivateAction();
        }

        public override void ActivateAction()
        {
            _damageable.Invincible = true;
        }

        protected override void DeactivateAction()
        {
            _damageable.Invincible = false;
        }
}