using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent-NoParams-On", menuName = "Game Events/No Params", order = -10)]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    public virtual void Invoke()
    {
        foreach (GameEventListener listener in listeners)
        {
            listener.Response.Invoke();
        }
    }
}
