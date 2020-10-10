using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableBools make it easy to share boolean values between GameObjects and can be given to ConditionedGameEvents in the editor UI.
[CreateAssetMenu (menuName = "ScriptableVars/ScriptableBool")]
public class ScriptableBool : ScriptableObject
{
    private bool initialVal = false;
    public bool val;

    //Without doing this initialVal assignment, SBool values would not be reset on scene load.
    //Could extend to load values based on save state.
    private void OnEnable()
    {
        val = initialVal;
    }
}
