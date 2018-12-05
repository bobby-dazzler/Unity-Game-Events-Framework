using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	public class TransitionHistory : History {

		public States toState;

		public override void Init(int _id) {
			id = _id;
		}
	}
}
