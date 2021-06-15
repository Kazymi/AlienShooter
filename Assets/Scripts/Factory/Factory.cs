using UnityEngine;

public class Factory
{
    private GameObject _spawnElement;
    private int _countElement;
    private Pool pool { get; set; }
    
    public Pool Pool => pool;

    public GameObject Create(Vector3 positionSpawn)
    {
       return pool.Pull();
    }

    public void Destoy(GameObject gameObject)
    {
        pool.Push(gameObject);
    }

    public virtual void InitializeFactory(GameObject spawnElement,int countElement)
    {
        _spawnElement = spawnElement;
        _countElement = countElement;
        pool = new Pool(_spawnElement, _countElement);
    }
}