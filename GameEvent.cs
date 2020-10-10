using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    public ScriptableBool BoolToSetWhenRaised;
    private List<GameEventListener> listeners = new List<GameEventListener>();

    //Raise event embedded with a parameter, triggering each listener.
    public void Raise(UnityEngine.Object val)
    {
        Debug.Log("Raising event: " + name);
        if(BoolToSetWhenRaised != null) BoolToSetWhenRaised.val = true;
        for (int i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(val);
    }

    public void Raise()
    {
        Raise(null);
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
