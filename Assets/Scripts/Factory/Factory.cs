using UnityEngine;

public abstract class Factory : ScriptableObject
{
    [SerializeField] private GameObject spawnElement;
    [SerializeField] private int countElement;

    protected Pool pool { get; set; }

    public Pool Pool => pool;
    public GameObject SpawnElement => spawnElement;

    public abstract void Create(Vector3 positionSpawn);

    public abstract void Create(Vector3 positionSpawn, Quaternion rotation);
    
    public virtual void InitializeFactory()
    {
        pool = new Pool(spawnElement, countElement);
    }
}