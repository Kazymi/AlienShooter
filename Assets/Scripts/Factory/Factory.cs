using UnityEngine;

public class Factory
{
    private GameObject _spawnElement;
    private int _countElement;
    
    private Pool pool { get; set; }

    public Factory(GameObject spawnElement,int countElement)
    {
        _spawnElement = spawnElement;
        _countElement = countElement;
        pool = new Pool(_spawnElement, _countElement);
    }

    public GameObject Create(Vector3 positionSpawn)
    {
       return pool.Pull();
    }

    public void Destroy(GameObject gameObject)
    {
        pool.Push(gameObject);
    }
}