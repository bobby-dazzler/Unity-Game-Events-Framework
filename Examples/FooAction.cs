using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventsFramework;

[CreateAssetMenu (menuName="Actions/Examples/Foo Action")]
public class FooAction : Action {

	public override void Act(StateController controller) {
		//thisEvent.StartEvent(controller);
	}

	public override void CreateHistory(StateController controller) {
		FooActionHistory hist = new FooActionHistory();
		controller.database.gameEventHistorySet.items[controller.database.gameEventHistorySet.Count() - 1].eventHistoryItems.Add(hist);
	}
}
