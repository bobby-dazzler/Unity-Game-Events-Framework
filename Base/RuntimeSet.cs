using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using Newtonsoft.Json; // Requires the Unity Asset 'JSON.NET for Unity' from asset store

namespace UnityEventsFramework {
	[System.Serializable]
	public abstract class RuntimeSet<T> : ScriptableObject {

		// Create a class which inherits from this, give it a type and then create a Scriptable Object instance of it
		// You can then assign it to any class which needs to access the data stored in it

		public string saveFileName = "";
		public string saveFolderName = "";

		[SerializeField]
		public List<T> items = new List<T>();

		//JsonSerializerSettings settings = new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All};

		public void Add(T item) {
			//if (!items.Contains(item)) {
				items.Add(item);
			//}
		}

		public void Insert(int index, T item) {
			items.Insert(index, item);
		}

		public void Remove(T item) {
			if (items.Contains(item)) {
				items.Remove(item);
			}
		}

		public void Clear () {
			for (int i = items.Count - 1; i >= 0; i--) {
				items.RemoveAt(i);
			}
		}

		public int Count () {
			return items.Count;
		}

/* Removed due to JSON conflict in new unity version
 		public string SaveToString () {
			string dataAsJson = JsonConvert.SerializeObject(this, Formatting.Indented, settings);
			return dataAsJson;
		} */

/* 		public void Save () {
			if (string.IsNullOrEmpty(saveFileName) ||  string.IsNullOrEmpty(saveFolderName)) {
				Debug.Log("Must enter file and folder name on the runtime set before saving");
				return;
			}

			string folder = Path.Combine(Application.streamingAssetsPath, saveFolderName);
			string filePath = Path.Combine(folder, saveFileName);

			string dataAsJson = this.SaveToString();
			File.WriteAllText(filePath, dataAsJson);  
		} */

/* 		public void Load (string fileName) {
			if (string.IsNullOrEmpty(fileName) ||  string.IsNullOrEmpty(saveFolderName)) {
				Debug.Log("Must enter file and folder name on the runtime set before saving");
				return;
			}
			string folder = Path.Combine(Application.streamingAssetsPath, saveFolderName);
			string filePath = Path.Combine(folder, fileName);
			
			if (File.Exists(filePath)) {
				string dataAsJson = File.ReadAllText(filePath);
				this = JsonConvert.DeserializeObject<RuntimeSet>(dataAsJson, settings);
			} else {
				Debug.Log("Unable to load action history file at: " + filePath);
			}
		} */
	}
}