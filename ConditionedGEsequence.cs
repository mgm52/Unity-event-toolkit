using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

//This class raises a sequence of conditioned game events.
[System.Serializable]
public class ConditionedGEsequence
{
    public List<ConditionedGameEvent> events;

    //Coroutines can only be started from MonoBehaviours. BUT if we make ConditionedGameEventSequence a MonoBehaviour, its properties won't be exposed in the inspector. So instead it takes in a caller.
    public void Raise(MonoBehaviour caller)
    {
        events.ForEach(e => caller.StartCoroutine(e.Raise()));
    }

    //This subclass lets us easily augment a GameEvent with a parameter, delay, and condition. It can be configured in the inspector. ConditionedGameEventSequence contains them.
    [System.Serializable]
    public class ConditionedGameEvent
    {
        [SerializeField]
        public GameEvent gameEvent;
        [SerializeField]
        public UnityEngine.Object eventParameter;

        public float waitTime = 0f;

        //The event will only trigger under certain conditions. If no SBool is assigned, it's true by default.
        public ScriptableBool activationCondition;
        public bool invertCondition = false;

        //Test whether the activationCondition has been met. If so, delay for waitTime seconds, then raise the gameEvent.
        public IEnumerator Raise()
        {
            bool available = activationCondition == null ? true : activationCondition.val;
            if (invertCondition) available = !available;

            if (available && gameEvent != null)
            {
                yield return new WaitForSeconds(waitTime);
                gameEvent.Raise(eventParameter);
            }

        }
    }

}
