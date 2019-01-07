using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
    [System.Serializable]
    [CreateAssetMenu (menuName = "Unity Events Framework/Enums/History Type")]
    public class HistoryType : ScriptableObject {

        public int index;

        public string description;

        public string SaveToString () {
            return JsonUtility.ToJson(this);
        }
    }
}