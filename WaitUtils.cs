using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUtils : MonoBehaviour
{
    //Wait then call action
    public static IEnumerator WaitThenDo(float time, Action a)
    {
        yield return new WaitForSeconds(time);
        a.Invoke();
    }

    //Wait then call action with a parameter T
    public static IEnumerator WaitThenDoT<T>(float time, Action<T> a, T p)
    {
        yield return new WaitForSeconds(time);
        a.Invoke(p);
    }
}
