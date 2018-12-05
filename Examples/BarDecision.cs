﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[CreateAssetMenu (menuName = "Decisions/Examples/Bar Decision")]
public class BarDecision : StateDecision {

	public override bool Decide(StateController controller) {
		float rand = Random.Range(0.0f, 1.0f);
		if (rand > 0.5) {
			return true;
		} else {
			return false;
		}
	}
}

