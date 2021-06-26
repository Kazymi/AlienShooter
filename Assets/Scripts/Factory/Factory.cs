using UnityEngine;

public class Factory
{
    private GameObject _spawnElement;
    private int _countElement;
    private Pool _pool;
    public Factory(GameObject spawnElement,int countElement, Transform parent)
    {
        _spawnElement = spawnElement;
        _countElement = countElement;
        _pool = new Pool(_spawnElement, _countElement,parent);
    }

    public GameObject Create(Vector3 positionSpawn)
    {
        var pull = _pool.Pull();
        pull.transform.position = positionSpawn;
        return pull;
    }

    public void Destroy(GameObject gameObject)
    {
        _pool.Push(gameObject);
    }
}