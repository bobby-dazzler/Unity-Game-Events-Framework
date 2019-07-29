using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEventsFramework;

//[CreateAssetMenu (menuName = "Unity Events Framework/Runtime Sets/Tasks Runtime Set")]
public class Playbook : MonoBehaviour {

    public string playbookName;

    public Task[] tasks;

    public void Play () {
        for (int i = 0; i < tasks.Length; i++) {
            Debug.Log(playbookName + ": starting task " + tasks[i].taskName);
            tasks[i].StartTask();
        }
    }
}