using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace UnityEventsFramework {
	[CreateAssetMenu(menuName = "Custom Classes/Log File")]
	public class LogFile : ScriptableObject {

		public string fileName;

		[HideInInspector]
		public string filePath {
			get { 
				string logFolderName = "Logs";
				string archiveFolderPath = Path.Combine(Application.streamingAssetsPath, logFolderName);
				return Path.Combine(archiveFolderPath, fileName);
			}	
		}

		public bool debugMode;
	}
}
