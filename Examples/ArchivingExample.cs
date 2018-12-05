using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEventsFramework;

public class ArchivingExample : MonoBehaviour {

	public Database exampleDatabase;

	void Start () {
		GenerateSomeActivity();
		SaveEventHistoryAsJson();

		//LoadJson();
	}

	void GenerateSomeActivity () {
		StateController controller = GameObject.Find("SomeObject").GetComponent<StateController>();
		// Start the event
		controller.currentState.CallActionAtIndex(0, controller);
		controller.currentState.UpdateState(controller);
		for (int i = 0; i < 50; i++) {
			float rand = Random.Range(0.0f, 1.0f);
			if (rand > 0.7) {
				controller.currentState.UpdateState(controller);
			} else {
				controller.currentState.CallActionAtIndex(Random.Range(0, controller.currentState.actions.Length), controller);
			}
		}
	}

	void SaveEventHistoryAsJson() {
		string historyDataFileName = "history.json";
		string archiveFolderName = "Archive";
		string archiveFolder = Path.Combine(Application.streamingAssetsPath, archiveFolderName);
		string filePath = Path.Combine(archiveFolder, historyDataFileName);

		exampleDatabase.CreateRuntimeSetAsJson(exampleDatabase.gameEventHistorySet, filePath);
	}

	void LoadJson () {
		string historyDataFileName = "history.json";
		string archiveFolderName = "Archive";
		string archiveFolder = Path.Combine(Application.streamingAssetsPath, archiveFolderName);
		string filePath = Path.Combine(archiveFolder, historyDataFileName);
		exampleDatabase.LoadHistoryFromJson(filePath);
		
 		for (int i = 0; i < 10; i++) { 
			Debug.Log(exampleDatabase.gameEventHistorySet.items[0].eventHistoryItems[i]);
		} 
	}

}
