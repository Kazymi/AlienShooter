using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerScanner : MonoBehaviour
{
    private PlayerLook _playerLook;
    private List<Transform> _targets = new List<Transform>();

    // TODO: "scanner" only looking for target and provides info on it
    private void Update()
    {
        CheckAllTargets();
        if (_targets.Count != 0)
        {
            // TODO: _playerLook should act on it's own
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
        foreach (var VARIABLE in _targets)
        {
            if (VARIABLE.gameObject.activeInHierarchy == false){ _targets.Remove(VARIABLE);}
            return;
        }
    }

    private Transform GetNearestEnemy()
    {
        // TODO: I've fixed the error. Now it works
        /*var closestDistance = Vector3.Distance(transform.position, _targets[0].position);
        var closestTarget = _targets[0];
        
        for (int i = 1; i < _targets.Count; i++)
        {
            var distance = Vector3.Distance(transform.position, _targets[i].position); // TODO: can be calculated without sqrt
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = _targets[i];
            }
        }
        return closestTarget;*/
        
        Dictionary<int, float> _targetsDistance = new Dictionary<int, float>();
        for (int i = 0; i < _targets.Count; i++)
        {
            _targetsDistance.Add(i,Distance(transform.position, _targets[i].position));
        }
        var sortedDict = from entry in _targetsDistance orderby entry.Value ascending select entry;
        foreach (var VARIABLE in sortedDict)
        {
            return _targets[VARIABLE.Key];
        }
        return null;
    }
    private float Distance(Vector3 a, Vector3 b)
    {
        float num1 = a.x - b.x;
        float num2 = a.y - b.y;
        float num3 = a.z - b.z;
        // TODO: It's actually returns square of distance
        return num1 * num1 + num2 * num2 + num3 * num3;
    }
    
    private void AddTarget(Transform target)
    {
        _targets.Add(target);
    }

    private void RemoveTarget(Transform target)
    {
        _targets.Remove(target);
    }
}
