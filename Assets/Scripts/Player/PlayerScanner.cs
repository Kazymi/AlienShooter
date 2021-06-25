using System.Collections.Generic;
using UnityEngine;

public class PlayerScanner : MonoBehaviour
{
    [SerializeField] private float radius;
    
    private PlayerLook _playerLook;
    private List<Transform> _targets = new List<Transform>();

    // TODO: "scanner" only looking for target and provides info on it
    private void Update()
    {
        CheckEnemy();
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

    private void CheckEnemy()
    {
        _targets = new List<Transform>();
        Collider[] hitColliders = new Collider[25];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, radius, hitColliders);
        for (int i = 0; i < numColliders; i++)
        {
            var j = hitColliders[i].GetComponent<ITarget>();
           if(j != null) _targets.Add(hitColliders[i].transform);
        }
    }

    private Transform GetNearestEnemy()
    {
        var closestDistance = Distance(transform.position, _targets[0].position);
        var closestTarget = _targets[0];
        
        for (int i = 1; i < _targets.Count; i++)
        {
            var distance = Distance(transform.position, _targets[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = _targets[i];
            }
        }
        return closestTarget;
    }
    private float Distance(Vector3 a, Vector3 b)
    {
        float num1 = a.x - b.x;
        float num2 = a.y - b.y;
        float num3 = a.z - b.z;
        // TODO: It's actually returns square of distance
        return num1 * num1 + num2 * num2 + num3 * num3;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
