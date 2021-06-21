using UnityEngine;

[CreateAssetMenu(fileName = "New speed effect",menuName = "Effect speed boost")]
public class BuffSpeedBoost : Effect
{
 private float _valueBoost;

 public override void ActivateBuffAction()
 {
  _changeSpeed.AddSpeed(_valueBoost);
 }

 public override void DeactivateBuffAction()
 {
  _changeSpeed.RemoveSpeed(_valueBoost);
 }

 public BuffSpeedBoost(IChangeSpeed changeSpeed, Damageable damageable, float timerEffect,float valueBoost) : base(changeSpeed, damageable, timerEffect)
 {
  _valueBoost = valueBoost;
 }
}