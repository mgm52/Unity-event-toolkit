using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MB_GameEventListener : MonoBehaviour
{
    [SerializeField]
    public ParameterisedUnityEvent Response;
    public SO_GameEvent Event;


    public void OnEventRaised(Object val)
    {
        // Debug.Log(gameObject.name + " recieved event: " + Event.name);
        Response.Invoke(val);
    }

    public void OnEnable()
    {
        // Debug.Log(gameObject.name + " listening to event: " + Event.name);
        Event.RegisterListener(this);
    }
    public void OnDisable()
    {
        // We unregister listeners to avoid listeners lists becoming needlessly long
        if(Event != null) Event.UnregisterListener(this);
    }
}

// This is necessary in order for parameterised unity events to show up in the inspector.
// UnityEvent<T> by itself is not serialized.
[System.Serializable]
public class ParameterisedUnityEvent : UnityEvent<Object> { }