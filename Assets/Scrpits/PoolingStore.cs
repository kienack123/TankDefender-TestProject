using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingStore : MonoBehaviour
{
    public static PoolingStore instance;
    public static PoolingStore Instance => instance;
    
    public List<GameObject> pooledObjects;
    
    public GameObject objectToPool;
    
    public int amountToPool;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    void Start()
    {
        CreatePooledObject();
    }


    private void CreatePooledObject()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void ReturnPoolingStore(GameObject _poolingObj)
    {
        _poolingObj.gameObject.SetActive(false);
        _poolingObj.gameObject.transform.position = Vector3.zero;
    }
    
    
    
}
