using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    OnBulletDied = 0
}

public static class EventManager
{
    private static Dictionary<EventType, System.Action> eventDictionary = new Dictionary<EventType, System.Action>();

    public static void AddListener(EventType type, System.Action action)
    {
        if (!eventDictionary.ContainsKey(type))
        {
            eventDictionary.Add(type, null);
        }
        eventDictionary[type] += action;
    }

    public static void RemoveListener(EventType type, System.Action action)
    {
        if (eventDictionary.ContainsKey(type) && eventDictionary[type] != null) { }
        eventDictionary[type] -= action;
    }

    public static void InvokeEvent(EventType type, System.Action action)
    {
        eventDictionary[type]?.Invoke();
    }
}
