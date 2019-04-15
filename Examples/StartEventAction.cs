using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[CreateAssetMenu (menuName="Unity Events Framework/Actions/Misc/Start Event Action")]
public class StartEventAction : Action {

	[HideInInspector]
	public override string OnActLogMessage {
		get {
			return "overrided " + onActLogMessage;
		}
	}

	public override void Act(StateController controller) {
		thisEvent.StartEvent(controller);
	}

	public override void CreateHistory(StateController controller) {
		// Start Event history is handled by the event so no need to create a history
	}

}
