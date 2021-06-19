using System;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    // TODO:
    /*
   
     // Base buff script, every concrete buff derives from it
     public abstract class Buff : ScriptableObject
    {
        [SerializedField] float activeTime;
        
        float _timer; 
    
        public abstract void Initialize(Player player);
         
        public virtual void OnActivation();
        public virtual bool Perform(); // Applies effect and counts timer. Returns true if timer is up.
    }
    
    // Main player component. Detects collisions with buffs. Activates effects.
     public class Buffer: MonoBehaviour
    {
      [SerializedField] List<Buff> buffs;
      
      List<Buff> _activeBuffs;
       
       public void Initialize()
       {
           foreach(var buff in buffs)
           {
               buff.Initialize(player);
           }
       }
       
       void OnTriggerEnter(Collision other)
       {
           var buff = other.GetComponent<BuffPickUp>();
           if(buff != null)
           {
               buff.OnActivation();  
           }
       }
       
       void Update()
       {
            foreach(var buff in buffs)
           {
               buff.Perform();
           }
       }
    }
    
    */
    private ISpeed _speed;
    private Damageable _damageable;

    private List<Buff> _buffs = new List<Buff>();
    private Dictionary<TypeBuff, Action> activateBuff = new Dictionary<TypeBuff, Action>();
    private Dictionary<TypeBuff, Action> deactivateBuff = new Dictionary<TypeBuff, Action>();

    private void Awake()
    {
        BuffActionInitialize();
    }

    private void Update()
    {
        CheckActiveBuffs();
        EffectsBuffs();
    }

    public void Initialize(ISpeed speed, Damageable damageable)
    {
        _speed = speed;
        _damageable = damageable;
    }

    public void TakeBuff(BuffConfiguration buffConfiguration)
    {
        for (int i = 0; i < _buffs.Count; i++)
        {
            if (_buffs[i].BuffConfiguration.TypeBuff == buffConfiguration.TypeBuff)
            {
                _buffs[i].TimeBuff += buffConfiguration.TimerBuff;
                return;
            }
        }
        _buffs.Add(new Buff(buffConfiguration));
    }

    private void CheckActiveBuffs()
    {
        for (int i = 0; i < _buffs.Count; i++)
        {
            _buffs[i].TimeBuff -= Time.deltaTime;
            if (_buffs[i].TimeBuff <= 0)
            {
                deactivateBuff[_buffs[i].BuffConfiguration.TypeBuff]?.Invoke();
                _buffs.Remove(_buffs[i]);
                return;
            }
        }
    }

    private void EffectsBuffs()
    {
        foreach (var i in _buffs)
        {
            activateBuff[i.BuffConfiguration.TypeBuff]?.Invoke();
        }
    }

    // TODO: stuff like this instantly looks wrong
    private void BuffActionInitialize()
    {
        activateBuff.Add(TypeBuff.Speed, () => _speed.AddBuff(TypeBuff.Speed, 2));
        activateBuff.Add(TypeBuff.Freeze, () => _speed.AddBuff(TypeBuff.Freeze, -4));
        activateBuff.Add(TypeBuff.Fire, () => _damageable.TakeDamage(3f * Time.deltaTime));
        activateBuff.Add(TypeBuff.Invincible, () => _damageable.Invincible = true);

        deactivateBuff.Add(TypeBuff.Speed, () => _speed.DeactivateBuff(TypeBuff.Speed));
        deactivateBuff.Add(TypeBuff.Freeze, () => _speed.DeactivateBuff(TypeBuff.Freeze));
        deactivateBuff.Add(TypeBuff.Fire, default);
        deactivateBuff.Add(TypeBuff.Invincible, default);
    }
}