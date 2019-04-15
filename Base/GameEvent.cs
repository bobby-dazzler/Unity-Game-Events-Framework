using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	public class GameEvent : ScriptableObject {

		private List<GameEventListener> listeners = new List<GameEventListener>();

		public virtual void StartEvent(StateController controller) {
		}

		public virtual void EndEvent(StateController controller) {

		}

		public virtual void CreateEventHistory(StateController controller) {
			GameEventHistory eventHistory = new GameEventHistory();
			controller.database.gameEventHistorySet.Add(eventHistory);
		}

		public void Raise () {
			for (int i = listeners.Count - 1; i >= 0; i--) {
				listeners[i].OnEventRaised();
			}
		}

		public void RegisterListener(GameEventListener listener) {
			// Called by GameEventListener.OnEnable()
			listeners.Add(listener);
		}

		public void UnregisterListener(GameEventListener listener) {
			listeners.Remove(listener);
		}
	}
}