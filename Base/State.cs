using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityEventsFramework {
	[CreateAssetMenu(menuName="Unity Events Framework/States/Generic State")]
	[Serializable]
	public class State : ScriptableObject {

		public Action[] actions;
		public Transition[] transitions;

		public void UpdateState (StateController controller) {
			CheckTransitions(controller);
			SetObservations(controller);
		}

		public virtual void SetObservations(StateController controller) {
			
		}

		public virtual void ConfigureState(StateController controller) {
			
		}

		public void CheckTransitions(StateController controller) {
			for (int i = 0; i < transitions.Length; i++) {
				bool decisionSucceeded = transitions[i].decision.Decide(controller);
				if (decisionSucceeded) {
					controller.TransitionToState(transitions[i].trueState);
				} else {
					controller.TransitionToState(transitions[i].falseState);
				}
			}
		}

		public void CallActionAtIndex(int index, StateController controller) {
			if (actions[index] == null) {
				Debug.Log("Attempting to call an action which is not assigned in actions array");
				//Debug.Log(index + " " + this);
			} else {
				actions[index].Act(controller);
			}
		}

		public virtual void TestState (StateController controller) {

		}
	}
}