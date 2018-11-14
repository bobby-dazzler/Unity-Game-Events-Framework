using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventsFramework {
	public class State : ScriptableObject {

		public States stateType;

		public JobComponentSystem[] systems;

		public Action[] actions;
		public Transition[] transitions;

		public bool[] archiveActions;
		public bool[] archiveStateTransitions;

		public bool[] logActions;
		public bool[] logStateTransitions;

		public LogFile logFile;

		[HideInInspector]
		public virtual string OnTransitionLogMessage {
			get {
				return onTransitionLogMessage;
			}
		}
		public string onTransitionLogMessage = "On Transition Log Message...";

		public HistoryType historyType;

		public void UpdateState (StateController controller) {
			CheckTransitions(controller);
			SetObservations(controller);
		}

		public virtual void SetObservations(StateController controller) {
			
		}

		public virtual void CreateHistory(StateController controller) {
			TransitionHistory hist = new TransitionHistory();
			hist.toState = stateType;
			controller.database.gameEventHistorySet.items[controller.database.gameEventHistorySet.Count() - 1].eventHistoryItems.Add(hist);
		}

		public void CheckTransitions(StateController controller) {
			for (int i = 0; i < transitions.Length; i++) {
				bool decisionSucceeded = transitions[i].decision.Decide(controller);
				if (decisionSucceeded) {
					controller.TransitionToState(transitions[i].trueState, archiveStateTransitions[i], logStateTransitions[i]);
				} else {
					controller.TransitionToState(transitions[i].falseState, archiveStateTransitions[i], logStateTransitions[i]);
				}
			}
		}

		public virtual void LogTransition (StateController controller) {
			if (logFile == null) {
				Debug.Log("Attempting to log a Transition on an object which does not have a Log File ScriptableObject assigned");
				return;
			}
			new LogWriter(onTransitionLogMessage, logFile.filePath);
		}

		public void CallActionAtIndex(int index, StateController controller) {
			//Debug.Log("Calling action: " + index);
			if (actions[index] == null) {
				Debug.Log("Attempting to call an action which is not assigned in actions array");
			} else {
				if (logActions[index]) {
					actions[index].LogAction(controller);
				}
				actions[index].Act(controller);
				if (archiveActions[index]) {
					actions[index].Archive(controller);
				}
			}
		}

		public virtual void TestState (StateController controller) {

		}
	}
}