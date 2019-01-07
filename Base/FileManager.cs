using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace UnityEventsFramework {
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

		void OnStartManageSettingsFile() {
			string fileName = "settings.json";
			string folderName = "Config";
			//string configFolder = Path.Combine(Application.streamingAssetsPath, folderName);
			string filePath = Path.Combine(folderName, fileName);

			if (!File.Exists(filePath)) {
				File.Create(filePath);
			}
		}
	}
}
