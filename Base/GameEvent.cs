using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	[CreateAssetMenu(menuName="Unity Events Framework/Game Events/Generic Event")]
	public class GameEvent : ScriptableObject {

		private List<GameEventListener> listeners = new List<GameEventListener>();

		public bool unregisterOnEnd;

		public void StartEvent(StateController controller) {
			// Change this to a virtual and create overrides if this isn't suitable
			Raise();
		}
		public void StartEvent() {
			// Change this to a virtual and create overrides if this isn't suitable
			Raise();
		}

		public  void EndEvent(StateController controller) {
			//////////////////////
			// THIS IS UNTESTED //
			//////////////////////

			//UnregisterListener();
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
			//////////////////////
			// THIS IS UNTESTED //
			//////////////////////
			
			
			for (int i = listeners.Count - 1; i >= 0; i--) {
				listeners.Remove(listener);
			}
			listeners.Clear();
		}
	}
}