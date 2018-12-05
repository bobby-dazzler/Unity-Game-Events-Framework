using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[System.Serializable]
public class FooActionHistory : History {

	public int fooInt = 19;

	public override void Init(int _id) {
		id = _id;
	}
}
