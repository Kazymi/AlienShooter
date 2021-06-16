using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private EnemyMove enemyMove;

   public void Initialize(EnemyConfiguration enemyConfiguration,Transform playerTranform)
   {
      enemyMove.Initialize(playerTranform,enemyConfiguration.Speed);
   }
}
