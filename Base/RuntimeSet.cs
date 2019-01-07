using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; // Requires the Unity JSON.Net asset

namespace UnityEventsFramework {
	[System.Serializable]
	public abstract class RuntimeSet<T> : ScriptableObject {

		// Create a class which inherits from this, give it a type and then create a Scriptable Object instance of it
		// You can then assign it to any class which needs to access the data stored in it

		public List<T> items = new List<T>();

		JsonSerializerSettings settings = new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All};

		public void Add(T item) {
			//if (!items.Contains(item)) {
				items.Add(item);
			//}
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

		public string SaveToString () {
			string dataAsJson = JsonConvert.SerializeObject(this, Formatting.Indented, settings);
			return dataAsJson;
		}
	}
}