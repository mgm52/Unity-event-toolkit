# Unity-event-toolkit

This is an extension of the GameEvent system suggested by Ryan Hipple (https://unity.com/how-to/architect-game-code-scriptable-objects), with a focus on allowing events to be configured in the Editor UI. New features include:
- Parameterised events - give your GameEvents an Object to transmit.
- GameEvent sequences - configure a sequence of GameEvents with custom timing.
- Conditioned GameEvents - use the new ScriptableBool class to prevent events from triggering unless a predicate has been met.

To complement these features, two classes with static methods are provided:
- WaitUtils to asynchronously delay method calls.
- ConvertUtils to cast Object types.
