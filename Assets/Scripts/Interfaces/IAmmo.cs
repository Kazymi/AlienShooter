using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmmo
{
   void Initialize(AmmoConfiguration ammoConfiguration, Factory factory);
}
