using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	public abstract class StateDecision : ScriptableObject {

		public abstract bool Decide (StateController controller);
	}
}