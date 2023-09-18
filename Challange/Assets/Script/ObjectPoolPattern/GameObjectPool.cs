using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool
{
    private List<GameObject> activePool = new List<GameObject>();
    private List<GameObject> inactivePool = new List<GameObject>();
    private GameObject prefab;

    public GameObjectPool(GameObject prefab)
    {
        this.prefab = prefab;
    }

    private GameObject AddNewItemToObjectPool()
    {
        GameObject instance = Object.Instantiate(prefab);
        instance.SetActive(false);
        inactivePool.Add(instance);
        return instance;
    }

    public GameObject RequestObject()
    {
        if (inactivePool.Count > 0)
        {
            return ActivateItem(inactivePool[0]);
        }
        return ActivateItem(AddNewItemToObjectPool());
    }

    public GameObject ActivateItem(GameObject item)
    {
        item.SetActive(true);
        if (inactivePool.Contains(item))
        {
            inactivePool.Remove(item);
        }
        activePool.Add(item);
        return item;
    }

    public void ReturnObjectToPool(GameObject item)
    {
        if (activePool.Contains(item))
        {
            activePool.Remove(item);
        }
        item.SetActive(false);
        inactivePool.Add(item);
    }
}
