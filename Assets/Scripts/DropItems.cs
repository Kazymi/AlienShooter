using System;
using System.Collections.Generic;

[Serializable]
public class DropItems
{
  public List<WeaponConfiguration> WeaponConfigurations = new List<WeaponConfiguration>();
  public List<EffectSystem> EffectSystems = new List<EffectSystem>();
}
