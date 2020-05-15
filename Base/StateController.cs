using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	public class StateController : MonoBehaviour {

		public Database database;

		public State currentState;
		
		public State remainState; // This is a Dummy generic state, if this is matched then we will not transition to a new state

		public bool debugMode;

		void Awake () {
			database = GetComponent<Database>();
			if (currentState != null) {
				currentState.ConfigureState(this);
			}
		}

		public void UpdateState() {
			currentState.UpdateState(this);
		}

		public void TransitionToState (State nextState, bool archiveTransition, bool logTransition) {
			// only change state if it's changed
			if (nextState != remainState) {
				if (logTransition == true) {
					nextState.LogTransition(this);				
				}
				currentState = nextState;
				currentState.ConfigureState(this);
				
				if (archiveTransition == true) {
					Database database = this.GetComponent<Database>();
					if (database == null) {
						Debug.Log("Attempting to archive a Transition on an object which does not have a Database component");
						return;
					}
					if (currentState.historyType == null) {
						Debug.Log("No history type assigned to Transition: " + this.name);
						return;
					}
					currentState.CreateHistory(this);
				}
			} 
		}

		public void CallCurrentStateActionAtIndex(int index) {
			currentState.CallActionAtIndex(index, this);
		}
	}
}