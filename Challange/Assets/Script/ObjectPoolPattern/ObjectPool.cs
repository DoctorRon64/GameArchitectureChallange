using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolabe
{
    private List<T> activePool = new List<T>();
    private List<T> inactivePool = new List<T>();

    private T AddNewItemToObjectPool()
    {
        T instance = (T)Activator.CreateInstance(typeof(T));
        inactivePool.Add(instance);
        return instance;
    }

    public T RequestObject()
    {
        if (inactivePool.Count > 0)
        {
            return ActivateItem(inactivePool[0]);
        }
        return ActivateItem(AddNewItemToObjectPool());
    }

    public T ActivateItem(T item)
    {
        item.EnablePoolabe();
        item.Active = true;
        if (inactivePool.Contains(item))
        {
            inactivePool.Remove(item);
        }
        activePool.Add(item);
        return item;
    }

    public void ReturnObjectToPool(T item)
    {
        item.DisablePoolabe();
        if (activePool.Contains(item))
        {
            activePool.Remove(item);
        }
        item.Active = false;
        inactivePool.Add(item);
    }
}
