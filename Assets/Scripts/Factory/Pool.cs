using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private List<GameObject> _pooledObjects;
    
    private readonly GameObject _elementSpawn;

    public Pool(GameObject element, int count)
    {
        _elementSpawn = element;
        Prepolulate(count);
    }

    public GameObject Pull()
    {
        GameObject returnValue;
        if (_pooledObjects.Count == 0) returnValue = CreateNewElement();
        else
        {
            returnValue = _pooledObjects[0];
            _pooledObjects.RemoveAt(0);
        }
        returnValue.SetActive(true);
        return returnValue;
    }

    public void Push(GameObject element)
    {
        element.SetActive(false);
        _pooledObjects.Add(element);
    }

    private void Prepolulate(int count)
    {
        _pooledObjects = new List<GameObject>();
        for (int i = 0; i != count; i++)
        {
            _pooledObjects.Add(CreateNewElement());
        }
    }

    private GameObject CreateNewElement()
    {
        var newElement = GameObject.Instantiate(_elementSpawn);
        newElement.SetActive(false);
        return newElement;
    }
}