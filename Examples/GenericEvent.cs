using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[CreateAssetMenu (menuName = "Unity Events Framework/Events/Misc/Generic Event")]
public class GenericEvent : GameEvent {

	public override void StartEvent(StateController controller) {
		if (controller.database != null) {
			CreateEventHistory(controller);
		}
		// Notify any listeners
		Raise();
	}

	public override void EndEvent(StateController controller) {
		//thisEvent.UnregisterListener();
	}
}
