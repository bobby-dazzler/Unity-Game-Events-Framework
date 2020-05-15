using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEventsFramework {
	[ExecuteInEditMode]
	public class GameEventListener : MonoBehaviour {

		public GameEvent Event;

		public UnityEvent response;

		void OnEnable () {
			Event.RegisterListener(this);
		}

		void OnDisable () {
			Event.UnregisterListener(this);
		}

		public void OnEventRaised() {
			response.Invoke();
		}
	}
}