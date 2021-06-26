using UnityEngine;

public abstract class Effect
    {
        public float Timer { get; set; }

        public virtual void ActivateAction()
        {
            
        }

        protected virtual void DeactivateAction()
        {
            
        }

        protected virtual void EffectOnTick()
        {
            
        }

        protected Effect(float timerEffect)
        {
            Timer = timerEffect;
        }
        
        public virtual bool CheckEffect()
        {
            EffectOnTick();
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                DeactivateAction();
                return true;
            }
            else return false;
        }
    }