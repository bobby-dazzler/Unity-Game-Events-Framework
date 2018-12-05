using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[System.Serializable]
public class BarActionHistory : History {

	public string testString = "Bar String";

	public override void Init(int _id) {
		id = _id;
	}
}