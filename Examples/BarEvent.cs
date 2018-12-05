﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[CreateAssetMenu (menuName = "Events/Examples/Bar Event")]
public class BarEvent : GameEvent {

	public override void StartEvent(StateController controller) {
		// Notify any listeners
		Raise();
	}

	public override void EndEvent(StateController controller) {
		//thisEvent.UnregisterListener();
	}
}
