using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogWriter  {

	public LogWriter(string message, string fileName) {
		WriteLog(message, fileName);
	}

	void WriteLog (string message, string filePath) {
		//string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
		if (File.Exists(filePath)) {
			using (StreamWriter writer = File.AppendText(filePath)) {
				Log(message, writer);
			}
		} else {
			Debug.Log("LogWriter.WriteLog() unable to find file at " + filePath);
		}
	}

	void Log (string message, TextWriter textWriter) {
		string content = System.DateTime.Now.ToString() + ": " + message + "\n";
		textWriter.Write(content);
	}
}