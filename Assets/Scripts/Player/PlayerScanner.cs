using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class PlayerScanner : MonoBehaviour
{
    private PlayerLook _playerLook;
    private List<Transform> _targerts = new List<Transform>();

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
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
            if (!VARIABLE.gameObject.activeSelf) _targerts.Remove(VARIABLE);
        }
    }
    private Transform GetNearestEnemy()
    {
        Dictionary<int, float> _targetsDistance = new Dictionary<int, float>();
        for (int i = 0; i < _targerts.Count; i++)
        {
            _targetsDistance.Add(i,Vector3.Distance(transform.position, _targerts[i].position));
        }
        var sortedDict = from entry in _targetsDistance orderby entry.Value ascending select entry;
        foreach (var VARIABLE in sortedDict)
        {
            return _targerts[VARIABLE.Key];
        }
        return null;
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
