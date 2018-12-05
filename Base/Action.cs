using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
	public abstract class Action : ScriptableObject {

		public GameEvent thisEvent;

		public HistoryType historyType;

		public string description = "Description...";

		[HideInInspector]
		public virtual string OnActLogMessage {
			get {
				// This can be overwritten on specific actions to create custom more complicated log messages
				return onActLogMessage;
			} 
		}
		public string onActLogMessage = "Action Log Message...";

		public LogFile logfile;

		public abstract void Act (StateController controller);

		public abstract void CreateHistory(StateController controller);

		public virtual void Archive (StateController controller) {
			//Database database = controller.GetComponent<Database>();
			if (controller.database == null) {
				Debug.Log("Attempting to archive an Action on an object which does not have a Database component");
				return;
			}
			if (historyType == null) {
				Debug.Log("No history type assigned to action: " + this.name);
				return;
			}

			// Create the sequential history record on the database component
			CreateHistory(controller);
			
		}

		public virtual void LogAction (StateController controller) {
			if (logfile == null) {
				Debug.Log("Attempting to log an action on an object which does not have a Log File ScriptableObject assigned");
				return;
			}
			new LogWriter(OnActLogMessage, logfile.filePath);
		}

		
	}
}
