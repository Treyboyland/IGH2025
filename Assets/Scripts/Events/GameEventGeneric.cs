using System.Collections.Generic;
using UnityEngine;

public class GameEvent<T> : GameEvent
{
    List<GameEventListenerGeneric<T>> listeners = new List<GameEventListenerGeneric<T>>();

    public T Value;

    public void AddListener(GameEventListenerGeneric<T> listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(GameEventListenerGeneric<T> listener)
    {
        listeners.Remove(listener);
    }

    public void Invoke(T value)
    {
        Value = value;
        Invoke();
    }

    public override void Invoke()
    {
        foreach (GameEventListenerGeneric<T> listener in listeners)
        {
            listener.Response.Invoke(Value);
        }
    }

}
