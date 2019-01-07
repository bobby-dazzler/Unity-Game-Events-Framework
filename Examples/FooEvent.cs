using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[CreateAssetMenu (menuName = "Unity Events Framework/Events/Examples/Foo Event")]
public class FooEvent : GameEvent {

	public override void StartEvent(StateController controller) {
		// Notify any listeners
		Raise();
	}

	public override void EndEvent(StateController controller) {
		//thisEvent.UnregisterListener();
	}
}