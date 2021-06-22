using UnityEngine;

public abstract class Effect
    {
        protected float _timer;
        public float Timer => _timer;

        public virtual void ActivateAction()
        {
            
        }

        public virtual void DeactivateAction()
        {
            
        }

        public virtual void EffectOnTick()
        {
            
        }

        public Effect(float timerEffect)
        {
            _timer = timerEffect;
        }
        
        public virtual bool CheckEffect()
        {
            EffectOnTick();
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                DeactivateAction();
                return true;
            }
            else return false;
        }
    }