using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace EventsFramework {
	public class FileManager : MonoBehaviour {

		public LogFileSet allLogFiles;

		void Awake () {
			OnStartManageLogFiles();
		}

		void OnStartManageLogFiles() {
			for (int i = 0; i < allLogFiles.Count(); i++) {
				string logsSubfolder = "Logs";
				string logsFolderPath = Path.Combine(Application.streamingAssetsPath, logsSubfolder);
				string logFilePath = Path.Combine(logsFolderPath, allLogFiles.items[i].fileName);

				if (File.Exists(logFilePath)) {
					File.Delete(logFilePath);
				}

				File.Create(logFilePath);

				if (!File.Exists(logFilePath)) {
					Debug.Log("Unable to create log file at: " + logFilePath);
				}
			}
		}
	}
}
