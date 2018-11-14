using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventsFramework {
	public class GameEventListener : MonoBehaviour {

		public GameEvent Event;

		public UnityEvent response;

		private void OnEnable () {
			Event.RegisterListener(this);
		}

		private void OnDisable () {
			Event.UnregisterListener(this);
		}

		public void OnEventRaised() {
			response.Invoke();
		}
	}
}