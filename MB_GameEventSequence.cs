using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

// This class raises a sequence of conditioned game events.
// Add as a component to configure its properties in the inspector.
[System.Serializable]
public class GameEventSequence : MonoBehaviour
{
    public bool raiseOnStart = false;
    public List<ConditionedGameEvent> events;

    public void Start()
    {
        if (raiseOnStart) Raise();
    }

    public void Raise()
    {
        events.ForEach(e => StartCoroutine(e.Raise()));
    }

    // This subclass lets us easily augment a GameEvent with a parameter, delay, and condition. It can be configured in the inspector. GameEventSequence contains them.
    [System.Serializable]
    public class ConditionedGameEvent
    {
        [SerializeField]
        public SO_GameEvent gameEvent;
        [SerializeField]
        public UnityEngine.Object eventParameter;

        public float waitTime = 0f;

        // The event will only trigger under certain conditions. If no SObool is assigned, it's true by default.
        public SO_ScriptableBool activationCondition;
        public bool invertCondition = false;

        // Test whether the activationCondition has been met. If so, delay for waitTime seconds, then raise the gameEvent.
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

