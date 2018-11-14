using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventsFramework {
	public abstract class StateDecision : ScriptableObject {

		public abstract bool Decide (StateController controller);
	}
}