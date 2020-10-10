using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertUtils
{
    //Try to convert an object to type T. If not possible, see if it's a GameObject containing a component of type T.
    public static T TryConvert<T>(Object o) where T : UnityEngine.Object
    {
        if (o is T) return (T)o;

        if(o is GameObject)
        {
            GameObject go = (GameObject)o;
            return go.GetComponent<T>();
        }

        return null;
    }
}
