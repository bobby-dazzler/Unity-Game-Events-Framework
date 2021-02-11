using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	public abstract class Action : ScriptableObject {

		public GameEvent thisEvent;

		public string description = "Description...";

		public bool debugMode = false;

		public abstract void Act (StateController controller);

		//public abstract void CreateHistory(StateController controller);
		
	}
}
