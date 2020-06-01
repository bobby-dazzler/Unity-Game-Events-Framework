using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using Newtonsoft.Json;  // Requires the Unity Asset 'JSON.NET for Unity' from asset store

namespace UnityEventsFramework {
	public class Database : MonoBehaviour {

		public GameEventHistorySet gameEventHistorySet;

/* 	Removed due to JSON conflict in new unity version	
		JsonSerializerSettings settings = new JsonSerializerSettings{
			TypeNameHandling = TypeNameHandling.All
		};
*/


		void Reset () {
			CheckEventSetIsNotNull();
		}

		void Awake () {
			CheckEventSetIsNotNull();
			ResetScriptableObjectsOnStart();
		}

		void ResetScriptableObjectsOnStart() {
			gameEventHistorySet.Clear();
		}

		public void CheckEventSetIsNotNull() {
			if (gameEventHistorySet != null) {
				return;
			} else {
				gameEventHistorySet = ScriptableObject.CreateInstance<GameEventHistorySet>();
			} 
		}

/* 	Removed due to JSON conflict in new unity version	
		public void CreateRuntimeSetAsJson(RuntimeSet<GameEventHistory> runtimeSet, string filePath) {
			string dataAsJson = runtimeSet.SaveToString();
			File.WriteAllText(filePath, dataAsJson);  
		}


public void LoadHistoryFromJson(string filePath) {
			if (File.Exists(filePath)) {
				string dataAsJson = File.ReadAllText(filePath);
				gameEventHistorySet = JsonConvert.DeserializeObject<GameEventHistorySet>(dataAsJson, settings);
			} else {
				Debug.Log("Unable to load action history file at: " + filePath);
			}
		}  */
	}
}
