using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEventsFramework;

[CreateAssetMenu (menuName="Unity Events Framework/Actions/Examples/Bar Action")]
public class BarAction : Action {

	public override void Act(StateController controller) {
		//thisEvent.StartEvent(controller);
	}

	public override void CreateHistory(StateController controller) {
		BarActionHistory hist = new BarActionHistory();
		controller.database.gameEventHistorySet.items[controller.database.gameEventHistorySet.Count() - 1].eventHistoryItems.Add(hist);
	}

}

