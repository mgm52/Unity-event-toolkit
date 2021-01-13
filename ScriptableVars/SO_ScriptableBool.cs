using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableVars/ScriptableBool")]
public class SO_ScriptableBool : ScriptableObject
{
    private bool initialVal = false;
    public bool val;

    // Without doing this  initialVal assignment, SO values would not be reset on scene load.
    // (note: tbh I don't know how saving game progress will work and how it will involve SOs, but doing this for now)
    private void OnEnable()
    {
        val = initialVal;
    }
}
