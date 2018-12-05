using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[CreateAssetMenu (menuName = "States/Misc/Generic State")]
public class GenericState : State {

    [HideInInspector]
    public override string OnTransitionLogMessage {
        get {
            return "Overrided " + onTransitionLogMessage;
        }
    }
}
