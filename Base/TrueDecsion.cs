using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[CreateAssetMenu(menuName = "Decisions/Generic/True")]
public class TrueDecsion : StateDecision {

	public override bool Decide (StateController controller) {
		// always return true
		return true;
	}
}
