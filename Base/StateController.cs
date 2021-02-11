using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	public class StateController : MonoBehaviour {

		public State currentState;
		
		public State remainState; // This is a Dummy generic state, if this is matched then we will not transition to a new state

		public bool debugMode;

		void Awake () {
			if (currentState != null) {
				currentState.ConfigureState(this);
			}
		}

		public void UpdateState() {
			currentState.UpdateState(this);
		}

		public void TransitionToState (State nextState) {
			// only change state if it's changed
			if (nextState != remainState) {
				currentState = nextState;
				currentState.ConfigureState(this);
			} 
		}

		public void CallCurrentStateActionAtIndex(int index) {
			currentState.CallActionAtIndex(index, this);
		}
	}
}