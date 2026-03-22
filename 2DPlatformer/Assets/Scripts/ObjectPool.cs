using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private List<GameObject> availableObjects;

    public ObjectPool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
        availableObjects = new List<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            availableObjects.Add(obj);
        }
    }

    public GameObject Get()
    {
        // Remove any destroyed objects from the pool
        availableObjects.RemoveAll(obj => obj == null);

        // Find inactive object
        foreach (GameObject obj in availableObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // No inactive objects → create new one
        GameObject newObj = GameObject.Instantiate(prefab);
        newObj.SetActive(true);
        availableObjects.Add(newObj);
        return newObj;
    }

    public void Return(GameObject obj)
    {
        if (obj == null) return; // <-- prevents missing reference errors
        obj.SetActive(false);
    }
}