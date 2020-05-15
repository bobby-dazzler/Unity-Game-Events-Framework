using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	[System.Serializable]
	public class Transition {

		public StateDecision decision;
		public State trueState;
		public State falseState; // if you don't actually want to transition to a different state on false, use the dummy remainState assigned in the StateController
	}
}