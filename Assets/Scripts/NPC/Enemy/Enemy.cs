using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private EnemyMove enemyMove;
   [SerializeField] private EnemyHealth enemyHealth;

   private Factory _parentFactory;
   public void Initialize(EnemyConfiguration enemyConfiguration,Transform playerTranform,Factory parentFactory)
   {
      _parentFactory = parentFactory;
      enemyMove.Initialize(playerTranform,enemyConfiguration.Speed);
      enemyHealth.Initialize(enemyConfiguration.HP,this);
   }

   public void DeadInitialize()
   {
      _parentFactory.Destroy(gameObject);
   }
}
