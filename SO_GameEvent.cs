using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_GameEvent : ScriptableObject
{
    public SO_ScriptableBool BoolToSetWhenRaised;

    private List<MB_GameEventListener> listeners = new List<MB_GameEventListener>();

    public void Raise(UnityEngine.Object val)
    {
        Debug.Log("Raising event: " + name);
        if(BoolToSetWhenRaised != null) BoolToSetWhenRaised.val = true;
        for (int i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(val);
    }

    public void Raise()
    {
        Debug.Log("Raising event: " + name);
        if (BoolToSetWhenRaised != null) BoolToSetWhenRaised.val = true;
        for (int i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(null);
    }

    public void RegisterListener(MB_GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(MB_GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
