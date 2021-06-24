using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnPosition : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float z;

    public float MaxX => x;
    public float MaxZ => z;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position,new Vector3(x,0.2f,z));
    }
}
