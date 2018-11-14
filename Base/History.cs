using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventsFramework {
    [System.Serializable]
    public abstract class History {

        public int id;

        //public string thisclass = "History";

        public abstract void Init(int _id);

        public virtual string SaveToString () {
            return JsonUtility.ToJson(this);
        }

    }
}