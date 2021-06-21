using UnityEngine;

public abstract class Effect
    {
        protected IChangeSpeed _changeSpeed;
        protected Damageable _damageable;
        protected float _timer;

        public virtual void ActivateBuffAction()
        {
            
        }

        public virtual void DeactivateBuffAction()
        {
            
        }

        public virtual void EffectOnTick()
        {
            
        }

        public Effect(IChangeSpeed changeSpeed, Damageable damageable, float timerEffect)
        {
            _changeSpeed = changeSpeed;
            _damageable = damageable;
            _timer = timerEffect;
            ActivateBuffAction();
        }
        
        public virtual bool CheckBuff()
        {
            EffectOnTick();
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                DeactivateBuffAction();
                return true;
            }
            else return false;
        }
    }