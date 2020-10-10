using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnStart : MonoBehaviour
{
    public GameEvent eventToRaiseOnStart;
    public Object eventParameter = null;

    void Start()
    {
        eventToRaiseOnStart.Raise(eventParameter);
    }
}
