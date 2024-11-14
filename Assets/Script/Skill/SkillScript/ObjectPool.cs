using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private List<GameObject> pool;
    private int initialPoolSize;
    private Transform parentTransform;
    public ObjectPool(GameObject _prefab, Vector3 position, Quaternion rotation, int _initialPoolSize)
    {
        prefab = _prefab;
        initialPoolSize = _initialPoolSize;
        pool = new List<GameObject>();
        parentTransform = new GameObject("ObjectPool").transform;

        for (int i = 0; i < initialPoolSize; i++)
        {
            (GameObject.Instantiate(prefab, position, rotation)).SetActive(false);

            GameObject obj = GameObject.Instantiate(prefab, position, rotation, parentTransform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = GameObject.Instantiate(prefab, parentTransform);  
        newObj.SetActive(false);     
        pool.Add(newObj);
        return newObj;
    }
    
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
    
}

