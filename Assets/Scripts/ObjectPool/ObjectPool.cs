using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T>  : MonoBehaviour where T : MonoBehaviour
{
    public static ObjectPool<T> SharedInstance;
    public List<T> pooledObjects;
    public T objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<T>();
        T tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i].gameObject;
            }
        }
        return null;
    }
}
