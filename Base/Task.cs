using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

[System.Serializable]
public class Task {

    public string taskName;

    public StateController stateController;

    public int actionIndex;

    public void StartTask() {
        //Debug.Log(stateController);
        stateController.CallCurrentStateActionAtIndex(actionIndex);
    }
}