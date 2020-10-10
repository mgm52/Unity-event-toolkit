using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    public ParameterisedUnityEvent Response;
    public GameEvent Event;

    //Call the UnityEvent configured in the Editor UI. It may be useful to cast the object in the called method using ConvertUtils.
    public void OnEventRaised(Object val)
    {
        Debug.Log(gameObject.name + " recieved event: " + Event.name);
        Response.Invoke(val);
    }

    public void OnEnable()
    {
        Event.RegisterListener(this);
    }

    public void OnDisable()
    {
        Event.UnregisterListener(this);
    }
}

//This is necessary in order for parameterised unity events to show up in the inspector.
//UnityEvent<T> by itself is not serialized.
[System.Serializable]
public class ParameterisedUnityEvent : UnityEvent<Object> { }
