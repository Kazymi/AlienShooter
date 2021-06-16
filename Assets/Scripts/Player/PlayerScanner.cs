using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerScanner : MonoBehaviour
{
    private PlayerLook _playerLook;
    private List<Transform> _targerts = new List<Transform>();

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true; // TODO: set it in editor
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        CheckAllTargets();
        if (_targerts.Count != 0)
        {
            _playerLook.LookAtTarget = true;
            _playerLook.Target = GetNearestEnemy();
        }
        else
        {
            _playerLook.LookAtTarget = false;
        }
    }
    
    public void Initialize(PlayerLook playerLook)
    {
        _playerLook = playerLook;
    }

    private void OnTriggerEnter(Collider other)
    {
        var i = other.GetComponent<ITarget>();
        if (i != null)
        {
            AddTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var i = other.GetComponent<ITarget>();
        if (i != null)
        {
            RemoveTarget(other.transform);
        }
    }

    private void CheckAllTargets()
    {
        foreach (var VARIABLE in _targerts)
        {
            if (VARIABLE.gameObject.activeSelf == false) _targerts.Remove(VARIABLE);
        }
    }

    private Transform GetNearestEnemy()
    {
        var closestDistance = Vector3.Distance(transform.position, _targerts[0].position);
        var closestTarget = _targerts[0];

        for (int i = 1; i < _targerts.Count; i++)
        {
            var distance = Vector3.Distance(transform.position, _targerts[0].position); // TODO: can be calculated without sqrt
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = _targerts[i];
            }
        }
        
        return closestTarget;
    }
    
    private void AddTarget(Transform target)
    {
        _targerts.Add(target);
    }

    private void RemoveTarget(Transform target)
    {
        _targerts.Remove(target);
    }
}
